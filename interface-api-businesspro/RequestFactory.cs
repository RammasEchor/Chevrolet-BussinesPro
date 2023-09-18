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
        var typename = GetTypeName(sr);
        var action = GetAction(sr);
        var id = GetId(action, sr);
        var registroJSON = GetJSON(action, sr);
        Registro registro = CreateClient(typename, id, registroJSON);
        return (registro, action);
    }

    private static Registro CreateClient(string typename, int id, string registroJSON)
    {
        return typename switch
        {
            "Empresa" => new Empresa(registroJSON, id),
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