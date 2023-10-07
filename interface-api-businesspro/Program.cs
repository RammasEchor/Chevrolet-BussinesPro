using System.Net;
using models_api_bussinesspro;

namespace Chevrolet.API.Interface;
class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Args: path_to_file success_dir error_dir");
            return;
        }

        string output = "";
        string output_dir = "";
        string path_to_file = args[0];
        string success_dir = args[1];
        string error_dir = args[2];

        try
        {
            var baseUrl = Environment.GetEnvironmentVariable("BUSSINES_PRO_BASE_URL");
            if (string.IsNullOrEmpty(baseUrl))
                throw new Exception("Bussines Pro Base Url is not set in the current environment.");

            (Registro registro, string action) = RequestFactory.CreateClientFromFile(ref path_to_file, ref baseUrl);
            switch (action)
            {
                case "Crear":
                    var resPost = await registro.POST();
                    break;

                case "Actualizar":
                    var resPut = await registro.PUT();
                    break;

                case "Eliminar":
                    var resDel = await registro.DELETE();
                    break;
            }

            output = "OK!";
            output_dir = success_dir;
        }
        catch (ApiException<CrmApiError> e)
        {
            output += e.Result.Codigo;
            output += ", ";
            output += e.Result.Mensaje;
            output += ", ";
            output += e.Result.Trace;

            output_dir = error_dir;
        }
        catch (ApiException e)
        {
            output = $"Error {e.StatusCode}: {((HttpStatusCode)e.StatusCode).ToString()}";
            output_dir = error_dir;
        }
        catch (Exception e)
        {
            output = e.Message;
            output_dir = error_dir;
        }
        finally
        {
            FileStreamOptions fileOptions = new()
            {
                Access = FileAccess.Write,
                Mode = FileMode.Append
            };
            using (StreamWriter writer = new(path_to_file, fileOptions))
            {
                string statusSeparator = "---------------FILE STATUS:---------------";
                string statusMessage = Environment.NewLine + statusSeparator;
                statusMessage += Environment.NewLine + output.Replace('\n', ',');
                Console.WriteLine($"{output.Replace('\n', ',')}");
                writer.WriteLine($"{Environment.NewLine}{Environment.NewLine}{DateTime.Now:dd MMM yyyy HH:mm}: {statusMessage}");
            };

            string filename = Path.GetFileName(path_to_file);
            File.Move(path_to_file, Path.Combine(output_dir, filename), true);
        }
    }
}




