using Newtonsoft.Json;

namespace models_api_bussinesspro;
public class Factura : Registro
{
    private readonly FacturaRequest? facturaRequest;

    public Factura(string json, int id = -1, int parentId = -1) : base(id, parentId)
    {
        facturaRequest = JsonConvert.DeserializeObject<FacturaRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return bussinesPro.Crear6Async(facturaRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return bussinesPro.Actualizar5Async(idFactura: null, idUnidadesCatalogoColor: id.ToString(), body: facturaRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return bussinesPro.Eliminar5Async(idFactura: id);
    }
}