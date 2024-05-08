using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Models;

public partial class CrearOrdenRequest
{
    [Key]
    [SwaggerSchema(ReadOnly = true)]
    public long Id { get; set; }
}