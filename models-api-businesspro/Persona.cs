using Newtonsoft.Json;

namespace models_api_businesspro;
public class Persona : Registro
{
    private readonly PersonaRequest? personaRequest;
    private readonly SucursalRequest? personaActualizarRequest;

    public Persona(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        personaRequest = JsonConvert.DeserializeObject<PersonaRequest>(json);
        personaActualizarRequest = JsonConvert.DeserializeObject<SucursalRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return businessPro.Crear9Async(personaRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        var task = businessPro.Actualizar9Async(idPersona: id, personaActualizarRequest);
        task.Wait(3000);
        return new Task<ActualizarResponse>(() =>
        {
            return new ActualizarResponse
            {
                Id = task.Result.Tpo_idtipo,
                FechaModifica = DateTime.Today.ToString()
            };
        });
    }

    override public Task<EliminarResponse> DELETE()
    {
        throw new Exception("Persona no tiene método DELETE.");
    }
}