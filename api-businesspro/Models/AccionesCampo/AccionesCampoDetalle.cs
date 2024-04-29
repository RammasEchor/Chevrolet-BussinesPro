using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Models;

public partial class AccionesCampoDetalleRequest
{
    [Key]
    [SwaggerSchema(ReadOnly = true)]
    public long Id { get; set; }

    [SwaggerSchema(ReadOnly = true)]
    public long AccionesCampoId { get; set; }
}