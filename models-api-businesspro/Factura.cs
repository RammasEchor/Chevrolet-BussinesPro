using Newtonsoft.Json;

namespace models_api_businesspro;
public class Factura : Registro
{
    private readonly FacturaRequest? facturaRequest;

    public Factura(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        facturaRequest = JsonConvert.DeserializeObject<FacturaRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return businessPro.Crear5Async(facturaRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return businessPro.Actualizar5Async(idFactura: null, idUnidadesCatalogoColor: id.ToString(), body: facturaRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return businessPro.Eliminar5Async(idFactura: id);
    }
}