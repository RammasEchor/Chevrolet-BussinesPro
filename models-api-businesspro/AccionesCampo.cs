using Newtonsoft.Json;

namespace models_api_bussinesspro;
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
        return bussinesPro.CrearAsync(crearAccionesCampoRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return bussinesPro.ActualizarAsync(idAccionesCampo: id, actualizarAccionesCampoRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return bussinesPro.EliminarAsync(idAccionesCampo: id);
    }
}