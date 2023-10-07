using Newtonsoft.Json;

namespace models_api_bussinesspro;
public class Cita : Registro
{
    private readonly CrearCitaRequest? crearCitaRequest;
    private readonly ActualizarCitaRequest? actualizarCitaRequest;

    public Cita(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        crearCitaRequest = JsonConvert.DeserializeObject<CrearCitaRequest>(json);
        actualizarCitaRequest = JsonConvert.DeserializeObject<ActualizarCitaRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return bussinesPro.Crear3Async(crearCitaRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return bussinesPro.Actualizar3Async(idCita: id, actualizarCitaRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return bussinesPro.Eliminar3Async(idCita: id);
    }
}