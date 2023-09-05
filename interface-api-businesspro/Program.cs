using System.Net.Http.Json;

namespace Chevrolet.API.Interface;
class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient client = HttpClientFactory.CreateClient(ref args);
        using StreamWriter outputFile = new("Chevrolet.txt");
        foreach (string arg in args)
        {
            await outputFile.WriteAsync($"{arg}");
        }
    }
}




