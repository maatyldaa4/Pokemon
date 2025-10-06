namespace Pokemon.ClientWrapper.Client
{
    public interface IExternalApiClient
    {
        Task<T> GetDataAsync<T>(string endpoint);
    }
}
