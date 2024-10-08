using System.Diagnostics;
using System.Net;
using System.Text;
using ChevroletToBusinessProInterface.Models;

namespace ChevroletToBusinessProInterface;
class Program
{
    static void Main()
    {
        Trace.Listeners.Add(new TextWriterTraceListener("interface-api-businessPro.log", "traceListener"));

        Directory.CreateDirectory($"{AppConfig.TopDir}");
        Directory.CreateDirectory($"{AppConfig.TopDir}/{AppConfig.NewRegistersDir}");
        Directory.CreateDirectory($"{AppConfig.TopDir}/{AppConfig.ProcessedDir}");
        Directory.CreateDirectory($"{AppConfig.TopDir}/{AppConfig.ErrorDir}");

        using var watcher = new FileSystemWatcher($"{AppConfig.TopDir}/{AppConfig.NewRegistersDir}");
        watcher.NotifyFilter = NotifyFilters.Attributes
                             | NotifyFilters.CreationTime
                             | NotifyFilters.DirectoryName
                             | NotifyFilters.FileName
                             | NotifyFilters.LastAccess
                             | NotifyFilters.LastWrite
                             | NotifyFilters.Security
                             | NotifyFilters.Size;
        watcher.InternalBufferSize = AppConfig.FileSystemBuffer;
        watcher.Filter = AppConfig.FilePattern;
        watcher.Created += ParseFile;
        watcher.Renamed += ParseFile;
        watcher.EnableRaisingEvents = true;

        ParseFilesAlreadyThere($"{AppConfig.TopDir}/{AppConfig.NewRegistersDir}");
        Trace.WriteLine("Watcher started.");
        Trace.Flush();
        Console.ReadLine();
    }

    private static void ParseFilesAlreadyThere(string path)
    {
        DirectoryInfo d = new(path);
        foreach (var file in d.GetFiles(AppConfig.FilePattern))
        {
            FileSystemEventArgs e = new(
                WatcherChangeTypes.Created,
                file.DirectoryName!,
                file.Name
            );
            Task.Run(() => ParseFile(null, e));
        }
    }

    static async void ParseFile(object? sender, FileSystemEventArgs eventArgs)
    {
        StringBuilder output_message = new();
        string output_dir = "";
        var path_to_file = eventArgs.FullPath;
        try
        {
            (Registro registro, string action) = RequestFactory.CreateClientFromFile(ref path_to_file);
            output_message.AppendLine(registro.GetJsonString());
            switch (action)
            {
                case "Crear":
                    await registro.POST();
                    break;

                case "Actualizar":
                    await registro.PUT();
                    break;

                case "Eliminar":
                    await registro.DELETE();
                    break;
            }

            output_message.AppendLine("OK!");
            output_dir = AppConfig.ProcessedDir;
        }
        catch (ApiException e)
        {
            output_message.AppendLine($"API Error {e.Response}: {((HttpStatusCode)e.StatusCode).ToString()}");
            output_dir = AppConfig.ErrorDir;
        }
        catch (Exception e)
        {
            output_message.AppendLine($"Local Error: {e.Message}");
            output_dir = AppConfig.ErrorDir;
        }
        finally
        {
            FileStreamOptions fileOptions = new()
            {
                Access = FileAccess.Write,
                Mode = FileMode.Append
            };
            using (StreamWriter writer = new(path_to_file, fileOptions))
            {
                string statusSeparator = "---------------FILE STATUS:---------------";
                string statusMessage = Environment.NewLine + statusSeparator;
                statusMessage += Environment.NewLine + output_message.ToString();
                writer.WriteLine($"{Environment.NewLine}{Environment.NewLine}{DateTime.Now:dd MMM yyyy HH:mm}: {statusMessage}");
            };

            Trace.WriteLine($"{eventArgs.Name}, moving to: {output_dir}");
            Trace.Flush();
            string filename = Path.GetFileName(path_to_file);
            output_dir = Path.Combine(AppConfig.TopDir!, output_dir);
            File.Move(path_to_file, Path.Combine(output_dir, filename), true);
        }
    }
}