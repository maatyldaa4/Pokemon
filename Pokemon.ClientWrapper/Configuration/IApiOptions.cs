namespace Pokemon.ClientWrapper.Configuration
{
    public interface IApiOptions
    {
        string BaseUrl { get; set; }
        int TimeoutSeconds { get; set; }
    }
}
