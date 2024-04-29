using Newtonsoft.Json;

namespace ChevroletToBusinessProInterface.Models;
public class Empresa : Registro
{
    private readonly EmpresaRequest? empresaRequest;

    public Empresa(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        empresaRequest = JsonConvert.DeserializeObject<EmpresaRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return businessPro.Crear4Async(empresaRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return businessPro.Actualizar4Async(id, empresaRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return businessPro.Eliminar4Async(id);
    }

    public override string GetJsonString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
