using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Models;

public partial class PersonaDatosFisicaRequest
{
    [Key]
    [SwaggerSchema(ReadOnly = true)]
    public long Id { get; set; }
}