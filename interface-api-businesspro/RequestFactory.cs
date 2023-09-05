namespace Chevrolet.API.Interface;
public static class HttpClientFactory
{
    public static HttpClient CreateClient(ref string[] args)
    {
        // var type = args[0];
        // switch (type)
        // {

        // }

        var httpClientHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
        };
        HttpClient client = new(httpClientHandler);
        return client;
    }
}