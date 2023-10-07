using System.Collections.Specialized;
using models_api_bussinesspro;

namespace Chevrolet.API.Interface;

public static class RequestFactory
{
    private static readonly StringCollection availableActions = new()
    {
        "Crear",
        "Actualizar",
        "Eliminar"
    };
    public static (Registro, string) CreateClientFromFile(ref string path, ref string baseUrl)
    {
        if (!Path.Exists(path))
            throw new Exception("El archivo no existe/No puede ser encontrado.");

        using StreamReader sr = new(path);
        string typename = GetTypeName(sr);
        string action = GetAction(sr);
        int id = GetId(action, sr);

        int parentId = -1;
        if (typename == "AccionesCampoDetalle" | typename == "OrdenDetalle")
            parentId = GetId(action, sr);

        string registroJSON = GetJSON(action, sr);
        Registro registro = CreateClient(baseUrl, typename, id, parentId, registroJSON);
        return (registro, action);
    }

    private static Registro CreateClient(string baseUrl, string typename, int id, int parentId, string registroJSON)
    {
        return typename switch
        {
            "AccionesCampo" => new AccionesCampo(baseUrl, registroJSON, id, parentId),
            "AccionesCampoDetalle" => new AccionesCampoDetalle(baseUrl, registroJSON, id, parentId),
            "Cita" => new Cita(baseUrl, registroJSON, id, parentId),
            "Empresa" => new Empresa(baseUrl, registroJSON, id, parentId),
            "Factura" => new Factura(baseUrl, registroJSON, id, parentId),
            "Orden" => new Orden(baseUrl, registroJSON, id, parentId),
            "OrdenDetalle" => new OrdenDetalle(baseUrl, registroJSON, id, parentId),
            "Paquetes" => new Paquetes(baseUrl, registroJSON, id, parentId),
            "Persona" => new Persona(baseUrl, registroJSON, id, parentId),
            "Sucursal" => new Sucursal(baseUrl, registroJSON, id, parentId),
            "Unidades" => new Unidades(baseUrl, registroJSON, id, parentId),
            "UnidadesColor" => new UnidadesColor(baseUrl, registroJSON, id, parentId),
            "Vehiculo" => new Vehiculo(baseUrl, registroJSON, id, parentId),
            _ => throw new Exception($"El tipo del registro no puede ser identificado: {typename}"),
        };
    }

    private static string GetTypeName(StreamReader sr)
    {
        return sr.ReadLine()?.Replace("\n", "") ?? throw new Exception($"Archivo vacío.");
    }

    private static string GetAction(StreamReader sr)
    {
        var action = sr.ReadLine()?.Replace("\n", "") ?? throw new Exception($"Acción vacía.");
        if (!availableActions.Contains(action))
        {
            throw new Exception($"El tipo de acción no pudo ser identificado: {action}");
        }

        return action;
    }

    private static int GetId(string action, StreamReader sr)
    {
        if (action == "Actualizar" || action == "Eliminar")
        {
            var id = sr.ReadLine() ?? throw new Exception($"Id vacío");
            return int.Parse(id);
        }

        return -1;
    }

    private static string GetJSON(string action, StreamReader sr)
    {
        if (action != "Eliminar")
        {
            return sr.ReadToEnd() ?? throw new Exception($"JSON vacío");
        }

        return "";
    }


}