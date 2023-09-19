using Newtonsoft.Json;

namespace models_api_bussinesspro;
public class Paquetes : Registro
{
    private readonly CrearPaqueteRequest? crearPaqueteRequest;
    private readonly ActualizarPaqueteRequest? actualizarPaqueteRequest;


    public Paquetes(string json, int id = -1, int parentId = -1) : base(id, parentId)
    {
        crearPaqueteRequest = JsonConvert.DeserializeObject<CrearPaqueteRequest>(json);
        actualizarPaqueteRequest = JsonConvert.DeserializeObject<ActualizarPaqueteRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return bussinesPro.Crear9Async(crearPaqueteRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return bussinesPro.Actualizar8Async(idPaquete: id, actualizarPaqueteRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return bussinesPro.Eliminar8Async(idPaquete: id);
    }
}