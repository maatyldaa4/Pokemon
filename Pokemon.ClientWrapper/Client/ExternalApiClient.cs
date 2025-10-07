using Serilog;
using System.Text.Json;

namespace Pokemon.ClientWrapper.Client
{
    public class ExternalApiClient(HttpClient httpClient, ILogger logger): IExternalApiClient
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ILogger _logger = logger;

        public async Task<T> GetDataAsync<T>(string endpoint, CancellationToken ct)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}{endpoint}", ct);

                if (!response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(
                        $"Request to '{endpoint}' failed with status {(int)response.StatusCode} ({response.ReasonPhrase}). " +
                        $"Response: {body}");
                }

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<T>(
                    content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (result != null)
                {
                    return result;
                }

                throw new InvalidOperationException($"Failed to deserialize response from '{endpoint}'.");
            }
            catch (HttpRequestException ex)
            {
                _logger.Error("HTTP error while calling '{Endpoint}': {ExceptionMessage}", endpoint, ex.Message);
                throw;
            }
            catch (TaskCanceledException ex)
            {
                _logger.Error("Request to '{Endpoint}' timed out: {ExceptionMessage}", endpoint, ex.Message);
                throw;
            }
            catch (JsonException ex)
            {
                _logger.Error("Invalid JSON returned from '{Endpoint}': {ExceptionMessage}", endpoint, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error("Unexpected error calling '{Endpoint}': {ExceptionMessage}", endpoint, ex.Message);
                throw;
            }
        }
    }
}
