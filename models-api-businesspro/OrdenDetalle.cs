using Newtonsoft.Json;

namespace models_api_bussinesspro;
public class OrdenDetalle : Registro
{
    private readonly CrearOrdenDetalleRequest? crearOrdenDetalleRequest;
    private readonly ActualizarOrdenDetalleRequest? actualizarOrdenDetalleRequest;

    public OrdenDetalle(string json, int id = -1, int parentId = -1) : base(id, parentId)
    {
        crearOrdenDetalleRequest = JsonConvert.DeserializeObject<CrearOrdenDetalleRequest>(json);
        actualizarOrdenDetalleRequest = JsonConvert.DeserializeObject<ActualizarOrdenDetalleRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return bussinesPro.Crear8Async(idServicioOrdenes: parentId, crearOrdenDetalleRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return bussinesPro.Actualizar7Async(idServicioOrdenes: parentId, consec: id, actualizarOrdenDetalleRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return bussinesPro.Eliminar7Async(idServicioOrdenes: parentId, consec: id);
    }
}