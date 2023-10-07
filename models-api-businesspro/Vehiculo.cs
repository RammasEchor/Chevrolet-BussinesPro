using Newtonsoft.Json;

namespace models_api_bussinesspro;
public class Vehiculo : Registro
{
    private readonly CrearVehiculoRequest? crearVehiculoRequest;
    private readonly ActualizarVehiculoRequest? actualizarVehiculoRequest;

    public Vehiculo(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        crearVehiculoRequest = JsonConvert.DeserializeObject<CrearVehiculoRequest>(json);
        actualizarVehiculoRequest = JsonConvert.DeserializeObject<ActualizarVehiculoRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return bussinesPro.Crear15Async(crearVehiculoRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return bussinesPro.Actualizar13Async(idVehiculo: id, actualizarVehiculoRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return bussinesPro.Eliminar12Async(idVehiculo: id);
    }
}