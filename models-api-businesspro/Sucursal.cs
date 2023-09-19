using Newtonsoft.Json;

namespace models_api_bussinesspro;
public class Sucursal : Registro
{
    private readonly SucursalRequest? sucursalRequest;

    public Sucursal(string json, int id = -1, int parentId = -1) : base(id, parentId)
    {
        sucursalRequest = JsonConvert.DeserializeObject<SucursalRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return bussinesPro.Crear12Async(sucursalRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return bussinesPro.Actualizar11Async(idSucursal: id, sucursalRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return bussinesPro.Eliminar10Async(idSucursal: id);
    }
}