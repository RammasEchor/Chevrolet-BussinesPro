using Newtonsoft.Json;

namespace ChevroletToBusinessProInterface.Models;
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
        return businessPro.Crear3Async(crearCitaRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return businessPro.Actualizar3Async(idCita: id, actualizarCitaRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return businessPro.Eliminar3Async(idCita: id);
    }

    public override string GetJsonString()
    {
        return JsonConvert.SerializeObject(this);
    }
}