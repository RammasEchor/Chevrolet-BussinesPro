using Newtonsoft.Json;

namespace models_api_businesspro;
public class Sucursal : Registro
{
    private readonly SucursalRequest? sucursalRequest;

    public Sucursal(string baseUrl, string json, int id = -1, int parentId = -1) : base(baseUrl, id, parentId)
    {
        sucursalRequest = JsonConvert.DeserializeObject<SucursalRequest>(json);
    }

    override public Task<CrearResponse> POST()
    {
        return businessPro.Crear10Async(sucursalRequest);
    }

    override public Task<ActualizarResponse> PUT()
    {
        return businessPro.Actualizar10Async(idSucursal: id, sucursalRequest);
    }

    override public Task<EliminarResponse> DELETE()
    {
        return businessPro.Eliminar9Async(idSucursal: id);
    }
}