using Newtonsoft.Json;

namespace models_api_bussinesspro;
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
        return bussinesPro.Crear7Async(crearOrdenRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return bussinesPro.Actualizar6Async(idServicioOrdenes: id, actualizarOrdenRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return bussinesPro.Eliminar6Async(idServicioOrdenes: id);
    }
}