using System.Diagnostics;

namespace ChevroletToBusinessProInterface;

public static class AppConfig
{
    private static readonly string? _topDir = Environment.GetEnvironmentVariable("API_INTERFACE_DIR");
    public static string TopDir
    {
        get
        {
            if (string.IsNullOrEmpty(_topDir))
            {
                Trace.WriteLine("WATCHER_TOP_DIRECTORY is not set.");
                Trace.Flush();
                Environment.Exit(1);
            }

            return _topDir;
        }
    }

    private static readonly string? _baseUrl = Environment.GetEnvironmentVariable("BUSINESS_PRO_BASE_URL");
    public static string BaseUrl
    {
        get
        {
            if (string.IsNullOrEmpty(_baseUrl))
            {
                {
                    Trace.WriteLine("CAR_BASE_URL is not set.");
                    Trace.Flush();
                    Environment.Exit(1);
                }
            }

            return _baseUrl;
        }
    }

    public static string NewRegistersDir { get; } = "NoProcesados";
    public static string ProcessedDir { get; } = "Procesados";
    public static string ErrorDir { get; } = "Erroneos";
    public static string FileExtenstionToCheck { get; } = ".READY";
    public static string FilePattern { get; } = "*" + FileExtenstionToCheck;
    public static int FileSystemBuffer { get; } = 65536;
}