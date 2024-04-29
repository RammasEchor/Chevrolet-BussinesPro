using Newtonsoft.Json;

namespace ChevroletToBusinessProInterface.Models;
public class UnidadesColor : Registro
{
    private readonly UnidadColorRequest? unidadColorRequest;

    public UnidadesColor(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        unidadColorRequest = JsonConvert.DeserializeObject<UnidadColorRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return businessPro.Crear12Async(unidadColorRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return businessPro.Actualizar11Async(idUnidadesCatalogoColor: id, unidadColorRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return businessPro.Eliminar10Async(idUnidadesCatalogoColor: id);
    }

    public override string GetJsonString()
    {
        return JsonConvert.SerializeObject(this);
    }
}