using Newtonsoft.Json;

namespace models_api_bussinesspro;
public class AccionesCampoDetalle : Registro
{
    private readonly AccionesCampoDetalleRequest? accionesCampoDetalleRequest;

    public AccionesCampoDetalle(string json, int id = -1, int parentId = -1) : base(id, parentId)
    {
        accionesCampoDetalleRequest = JsonConvert.DeserializeObject<AccionesCampoDetalleRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return bussinesPro.Crear2Async(idAccionesCampo: parentId, accionesCampoDetalleRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return bussinesPro.Actualizar2Async(idAccionesCampo: parentId, idAccionesCampoDetalle: id, accionesCampoDetalleRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return bussinesPro.Eliminar2Async(idAccionesCampo: parentId, idAccionesCampoDetalle: id);
    }
}