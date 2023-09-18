using Newtonsoft.Json;

namespace models_api_bussinesspro;
public class Empresa : Registro
{
    private readonly EmpresaRequest? empresaRequest;

    public Empresa(string json, int id = -1, int parentId = -1) : base(id, parentId)
    {
        empresaRequest = JsonConvert.DeserializeObject<EmpresaRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return bussinesPro.Crear5Async(empresaRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return bussinesPro.Actualizar4Async(id, empresaRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return bussinesPro.Eliminar4Async(id);
    }
}
