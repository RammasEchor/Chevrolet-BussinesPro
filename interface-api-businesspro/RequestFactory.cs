using System.Collections.Specialized;
using models_api_businesspro;

namespace Chevrolet.API.Interface;

public static class RequestFactory
{
    private static readonly StringCollection availableActions = new()
    {
        "Crear",
        "Actualizar",
        "Eliminar"
    };
    public static (Registro, string) CreateClientFromFile(ref string path)
    {
        if (!Path.Exists(path))
            throw new Exception("El archivo no existe/No puede ser encontrado.");

        using StreamReader sr = new(path);
        string typename = GetTypeName(sr);
        string action = GetAction(sr);
        int id = GetId(action, sr);
        var infoList = GetInfoList(sr);
        Registro registro = CreateClient(typename, id, infoList);
        return (registro, action);
    }

    private static Registro CreateClient(string typename, int id, List<string> infoList)
    {
        return typename switch
        {
            // "AccionesCampo" => new AccionesCampo(baseUrl, registroJSON, id, parentId),
            // "AccionesCampoDetalle" => new AccionesCampoDetalle(baseUrl, registroJSON, id, parentId),
            // "Cita" => new Cita(baseUrl, registroJSON, id, parentId),
            // "Empresa" => new Empresa(baseUrl, registroJSON, id, parentId),
            // "Factura" => new Factura(baseUrl, registroJSON, id, parentId),
            // "Orden" => new Orden(baseUrl, registroJSON, id, parentId),
            // "OrdenDetalle" => new OrdenDetalle(baseUrl, registroJSON, id, parentId),
            // "Paquetes" => new Paquetes(baseUrl, registroJSON, id, parentId),
            // "Persona" => new Persona(baseUrl, registroJSON, id, parentId),
            // "Sucursal" => new Sucursal(baseUrl, registroJSON, id, parentId),
            "Unidades" => new Unidades(AppConfig.BaseUrl, infoList, id),
            // "UnidadesColor" => new UnidadesColor(baseUrl, registroJSON, id, parentId),
            // "Vehiculo" => new Vehiculo(baseUrl, registroJSON, id, parentId),
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

    private static List<string> GetInfoList(StreamReader sr)
    {
        string allInfo = sr.ReadToEnd() ?? throw new Exception("There is not info after action.");
        var trimmedInfo = new List<string>();
        char[] delimiterChars = { '\n', '\r' };
        Array.ForEach(allInfo.Split(delimiterChars), s => trimmedInfo.Add(s.Trim()));
        return trimmedInfo;
    }
}