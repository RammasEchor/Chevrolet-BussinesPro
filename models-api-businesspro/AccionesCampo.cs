using Newtonsoft.Json;

namespace models_api_businesspro;
public class AccionesCampo : Registro
{
    private readonly CrearAccionesCampoRequest? crearAccionesCampoRequest;
    private readonly ActualizarAccionesCampoRequest? actualizarAccionesCampoRequest;

    public AccionesCampo(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        crearAccionesCampoRequest = JsonConvert.DeserializeObject<CrearAccionesCampoRequest>(json);
        actualizarAccionesCampoRequest = JsonConvert.DeserializeObject<ActualizarAccionesCampoRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return businessPro.CrearAsync(crearAccionesCampoRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return businessPro.ActualizarAsync(idAccionesCampo: id, actualizarAccionesCampoRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return businessPro.EliminarAsync(idAccionesCampo: id);
    }
}