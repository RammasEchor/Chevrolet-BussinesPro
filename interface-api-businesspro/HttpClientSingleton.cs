namespace ChevroletToBusinessProInterface;

public static class HttpClientSingleton
{
    private static readonly Lazy<HttpClient> _httpClient = new(() =>
        {
            return new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
            });
        });
    public static HttpClient HttpClient
    {
        get
        {
            return _httpClient.Value;
        }
    }
}