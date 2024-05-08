using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Models;

public partial class UnidadColorRequest
{
    [Key]
    [SwaggerSchema(ReadOnly = true)]
    public long Id { get; set; }

    [SwaggerSchema(ReadOnly = true)]
    public long UnidadID { get; set; }

    [JsonIgnore]
    [SwaggerSchema(ReadOnly = true)]
    public CrearUnidadRequest Unidad { get; set; }
}