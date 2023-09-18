
using NSwag;
using NSwag.CodeGeneration.CSharp;

System.Net.WebClient wclient = new();

var document = await OpenApiDocument.FromJsonAsync(wclient.DownloadString("http://45.189.154.9:2000/swagger/v1/swagger.json"));

wclient.Dispose();

var settings = new CSharpClientGeneratorSettings
{
    ClassName = "BussinesPro",
    CSharpGeneratorSettings =
    {
        Namespace = "models_api_bussinesspro",
    }
};

var generator = new CSharpClientGenerator(document, settings);
var code = generator.GenerateFile();

using StreamWriter outputFile = new(@"../models-api-bussinesspro/gen-code.cs");
outputFile.Write(code);


