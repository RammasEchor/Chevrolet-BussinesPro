using Newtonsoft.Json;

namespace models_api_bussinesspro;
public class Unidades : Registro
{
    private readonly CrearUnidadRequest? crearUnidadRequest;

    public Unidades(string json, int id = -1, int parentId = -1) : base(id, parentId)
    {
        crearUnidadRequest = JsonConvert.DeserializeObject<CrearUnidadRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        var task = bussinesPro.Crear13Async(crearUnidadRequest);
        task.Wait(3000);
        return new Task<CrearResponse>(() =>
        {
            return new CrearResponse
            {
                Id = task.Result.IdUnidadesCatalogo,
                FechaAlta = task.Result.FechaAlta
            };
        });

    }

    override public Task<ActualizarResponse> PUT()
    {
        throw new Exception("Unidades no tiene método PUT.");
    }

    override public Task<EliminarResponse> DELETE()
    {
        throw new Exception("Unidades no tiene método DELETE.");
    }
}