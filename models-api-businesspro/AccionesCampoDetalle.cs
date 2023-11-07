using Newtonsoft.Json;

namespace models_api_businesspro;
public class AccionesCampoDetalle : Registro
{
    private readonly AccionesCampoDetalleRequest? accionesCampoDetalleRequest;

    public AccionesCampoDetalle(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        accionesCampoDetalleRequest = JsonConvert.DeserializeObject<AccionesCampoDetalleRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return businessPro.Crear2Async(idAccionesCampo: parentId, accionesCampoDetalleRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return businessPro.Actualizar2Async(idAccionesCampo: parentId, idAccionesCampoDetalle: id, accionesCampoDetalleRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return businessPro.Eliminar2Async(idAccionesCampo: parentId, idAccionesCampoDetalle: id);
    }
}