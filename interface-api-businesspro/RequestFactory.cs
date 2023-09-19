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
    public static (Registro, string) CreateClientFromFile(ref string path)
    {
        if (!Path.Exists(path))
            throw new Exception("El archivo no existe/No puede ser encontrado.");

        StreamReader sr = new(path);
        string typename = GetTypeName(sr);
        string action = GetAction(sr);
        int id = GetId(action, sr);

        int parentId = -1;
        if (typename == "AccionesCampoDetalle" | typename == "OrdenDetalle")
            parentId = GetId(action, sr);

        string registroJSON = GetJSON(action, sr);
        Registro registro = CreateClient(typename, id, parentId, registroJSON);
        return (registro, action);
    }

    private static Registro CreateClient(string typename, int id, int parentId, string registroJSON)
    {
        return typename switch
        {
            "AccionesCampo" => new AccionesCampo(registroJSON, id, parentId),
            "AccionesCampoDetalle" => new AccionesCampoDetalle(registroJSON, id, parentId),
            "Cita" => new Cita(registroJSON, id, parentId),
            "Empresa" => new Empresa(registroJSON, id, parentId),
            "Factura" => new Factura(registroJSON, id, parentId),
            "Orden" => new Orden(registroJSON, id, parentId),
            "OrdenDetalle" => new OrdenDetalle(registroJSON, id, parentId),
            "Paquetes" => new Paquetes(registroJSON, id, parentId),
            "Persona" => new Persona(registroJSON, id, parentId),
            "Sucursal" => new Sucursal(registroJSON, id, parentId),
            "Unidades" => new Unidades(registroJSON, id, parentId),
            "UnidadesColor" => new UnidadesColor(registroJSON, id, parentId),
            "Vehiculo" => new Vehiculo(registroJSON, id, parentId),
            _ => throw new Exception($"El tipo del registro no puede ser identificado: {typename}"),
        };
    }

    private static string GetTypeName(StreamReader sr)
    {
        return sr.ReadLine() ?? throw new Exception($"Archivo vacío.");
    }

    private static string GetAction(StreamReader sr)
    {
        var action = sr.ReadLine() ?? throw new Exception($"Acción vacía.");
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