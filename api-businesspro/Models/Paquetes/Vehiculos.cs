using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Models;

public partial class CrearPaqueteVehiculoResquest
{
    [Key]
    [SwaggerSchema(ReadOnly = true)]
    public long Id { get; set; }

    [SwaggerSchema(ReadOnly = true)]
    public long PaqueteID { get; set; }

    [JsonIgnore]
    [SwaggerSchema(ReadOnly = true)]
    public CrearPaqueteRequest Paquete { get; set; }
}