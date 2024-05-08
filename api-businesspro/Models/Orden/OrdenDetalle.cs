using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Models;

public partial class CrearOrdenDetalleRequest
{
    [Key]
    [SwaggerSchema(ReadOnly = true)]
    public long Id { get; set; }

    [SwaggerSchema(ReadOnly = true)]
    public long OrdenID { get; set; }

    [JsonIgnore]
    [SwaggerSchema(ReadOnly = true)]
    public CrearOrdenRequest Orden { get; set; }
}