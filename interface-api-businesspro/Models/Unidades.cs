using Newtonsoft.Json;

namespace ChevroletToBusinessProInterface.Models;
public class Unidades : Registro
{
    private readonly CrearUnidadRequest? crearUnidadRequest;

    public Unidades(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        crearUnidadRequest = JsonConvert.DeserializeObject<CrearUnidadRequest>(json);
    }

    public Unidades(string baseUrl, List<string> infoList, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        // crearUnidadRequest = JsonConvert.DeserializeObject<CrearUnidadRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        var task = businessPro.Crear11Async(crearUnidadRequest);
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

    public override string GetJsonString()
    {
        return JsonConvert.SerializeObject(this);
    }
}