using System.Net;
using models_api_bussinesspro;

namespace Chevrolet.API.Interface;
class Program
{
    static async Task Main(string[] args)
    {
        string output = "";
        try
        {
            var path = "EjemplosJSON/Empresa/EmpresaEliminar.txt";
            (Registro registro, string action) = RequestFactory.CreateClientFromFile(ref path);
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
        }
        catch (ApiException<CrmApiError> e)
        {
            output += e.Result.Codigo;
            output += ", ";
            output += e.Result.Mensaje;
            output += ", ";
            output += e.Result.Trace;
        }
        catch (ApiException e)
        {
            output = $"Error {e.StatusCode}: {((HttpStatusCode)e.StatusCode).ToString()}";
        }
        catch (Exception e)
        {
            output = e.Message;
        }
        finally
        {
            FileStreamOptions fileOptions = new()
            {
                Access = FileAccess.Write,
                Mode = FileMode.Append
            };
            using StreamWriter writer = new(Path.Combine("ERRORS", "errors.txt"), fileOptions);
            writer.WriteLine($"{DateTime.Now:dd MMM yyyy HH:mm}: {output.Replace('\n', ',')}");
        }
    }
}




