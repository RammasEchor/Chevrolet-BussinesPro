﻿
using NSwag;
using NSwag.CodeGeneration.CSharp;

HttpClient wclient = new();

var document = await OpenApiDocument.FromJsonAsync(await wclient.GetStringAsync("http://45.189.154.9:2000/swagger/v1/swagger.json"));

wclient.Dispose();

var settings = new CSharpClientGeneratorSettings
{
    ClassName = "BusinessPro",
    CSharpGeneratorSettings =
    {
        Namespace = "models_api_businesspro",
    }
};

var generator = new CSharpClientGenerator(document, settings);
var code = generator.GenerateFile();

using StreamWriter interfaceModels = new(@"../interface-api-businesspro/Models/gen-code.cs");
using StreamWriter apiModels = new(@"../api-businesspro/Models/gen-code.cs");
interfaceModels.Write(code);
apiModels.Write(code);


