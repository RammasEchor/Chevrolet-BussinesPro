using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Models;

public partial class AccionesCampoSeriesRequest
{
    [Key]
    [SwaggerSchema(ReadOnly = true)]
    public long Id { get; set; }

    [SwaggerSchema(ReadOnly = true)]
    public long AccionCampoID { get; set; }

    [JsonIgnore]
    [SwaggerSchema(ReadOnly = true)]
    public CrearAccionesCampoRequest AccionCampo { get; set; }
}