using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Models;

public partial class CrearAccionesCampoRequest
{
    [Key]
    [SwaggerSchema(ReadOnly = true)]
    public long Id { get; set; }
}