using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecnicosRegistros.Models;
public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras y vocales con tilde.")]
    [Required(ErrorMessage = "Es obligatorio introducir el Nombre del técnico.")]
    public string Nombres { get; set; }
    [Range(0.01, float.MaxValue, ErrorMessage = "Es obligatorio introducir el SueldoHora")]
    public decimal SueldoHora { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    [ForeignKey("TipoId")]
    public int TipoId { get; set; }
}