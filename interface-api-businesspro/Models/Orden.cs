using Newtonsoft.Json;

namespace ChevroletToBusinessProInterface.Models;
public class Orden : Registro
{
    private readonly CrearOrdenRequest? crearOrdenRequest;
    private readonly ActualizarOrdenRequest? actualizarOrdenRequest;

    public Orden(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        crearOrdenRequest = JsonConvert.DeserializeObject<CrearOrdenRequest>(json);
        actualizarOrdenRequest = JsonConvert.DeserializeObject<ActualizarOrdenRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return businessPro.Crear6Async(crearOrdenRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return businessPro.Actualizar6Async(idServicioOrdenes: id, actualizarOrdenRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return businessPro.Eliminar6Async(idServicioOrdenes: id);
    }

    public override string GetJsonString()
    {
        return JsonConvert.SerializeObject(this);
    }
}