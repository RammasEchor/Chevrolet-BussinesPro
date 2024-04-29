using Newtonsoft.Json;

namespace ChevroletToBusinessProInterface.Models;
public class OrdenDetalle : Registro
{
    private readonly CrearOrdenDetalleRequest? crearOrdenDetalleRequest;
    private readonly ActualizarOrdenDetalleRequest? actualizarOrdenDetalleRequest;

    public OrdenDetalle(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        crearOrdenDetalleRequest = JsonConvert.DeserializeObject<CrearOrdenDetalleRequest>(json);
        actualizarOrdenDetalleRequest = JsonConvert.DeserializeObject<ActualizarOrdenDetalleRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return businessPro.Crear7Async(idServicioOrdenes: parentId, crearOrdenDetalleRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return businessPro.Actualizar7Async(idServicioOrdenes: parentId, consec: id, actualizarOrdenDetalleRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return businessPro.Eliminar7Async(idServicioOrdenes: parentId, consec: id);
    }

    public override string GetJsonString()
    {
        return JsonConvert.SerializeObject(this);
    }
}