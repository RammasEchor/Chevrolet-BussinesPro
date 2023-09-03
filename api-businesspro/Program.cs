
namespace Chevrolet.API
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapPost("/user", (ChevroletUser user) =>
            {
                Console.WriteLine($"{user}");
                return Results.Accepted();
            });

            app.Run();
        }
    }
}

