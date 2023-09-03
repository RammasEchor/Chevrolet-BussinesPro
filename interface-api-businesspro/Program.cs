using System.Net.Http.Json;

namespace Chevrolet.API.Interface
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
            };
            using HttpClient client = new(httpClientHandler);
            await ProcessRepositoriesAsync(client);
        }

        static async Task ProcessRepositoriesAsync(HttpClient client)
        {
            var user = new ChevroletUser
            {
                Id = 1,
                Name = "Test",
                IsComplete = false
            };

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "http://localhost:5000/user", user
            );
            response.EnsureSuccessStatusCode();

            Console.WriteLine("response");
        }
    }
}




