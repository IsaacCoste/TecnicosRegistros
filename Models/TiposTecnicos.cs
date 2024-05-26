using System.ComponentModel.DataAnnotations;
namespace TecnicosRegistros.Models;
public class TiposTecnicos
{
    [Key]
    public int TipoId { get; set; }
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras y vocales con tilde.")]
    [Required(ErrorMessage = "Es obligatorio introducir la Descripcion del técnico.")]
    public string Descripcion { get; set; }
    public decimal? Incentivo { get; set; }
    public Tecnicos? Tecnicos { get; set; }
}