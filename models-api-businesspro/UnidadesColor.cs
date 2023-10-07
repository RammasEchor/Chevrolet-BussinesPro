using Newtonsoft.Json;

namespace models_api_bussinesspro;
public class UnidadesColor : Registro
{
    private readonly UnidadColorRequest? unidadColorRequest;

    public UnidadesColor(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        unidadColorRequest = JsonConvert.DeserializeObject<UnidadColorRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return bussinesPro.Crear14Async(unidadColorRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return bussinesPro.Actualizar12Async(idUnidadesCatalogoColor: id, unidadColorRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return bussinesPro.Eliminar11Async(idUnidadesCatalogoColor: id);
    }
}