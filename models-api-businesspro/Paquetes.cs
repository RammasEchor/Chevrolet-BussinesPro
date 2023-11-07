using Newtonsoft.Json;

namespace models_api_businesspro;
public class Paquetes : Registro
{
    private readonly CrearPaqueteRequest? crearPaqueteRequest;
    private readonly ActualizarPaqueteRequest? actualizarPaqueteRequest;


    public Paquetes(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        crearPaqueteRequest = JsonConvert.DeserializeObject<CrearPaqueteRequest>(json);
        actualizarPaqueteRequest = JsonConvert.DeserializeObject<ActualizarPaqueteRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return businessPro.Crear8Async(crearPaqueteRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return businessPro.Actualizar8Async(idPaquete: id, actualizarPaqueteRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return businessPro.Eliminar8Async(idPaquete: id);
    }
}