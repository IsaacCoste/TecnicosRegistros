using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TecnicosRegistros.Models;
public class Incentivos
{
    [Key]
    public int IncentivoId { get; set; }
    [Required(ErrorMessage = "El campo Fecha es obligatorio")]
    public DateTime Fecha { get; set; }
    [Required(ErrorMessage = "El campo Tecnico es obligatorio")]
    [ForeignKey("Tecnicos")]
    public int TecnicoId { get; set; }
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras y vocales con tilde.")]
    [Required(ErrorMessage = "Es obligatorio introducir la descripcion del Incentivo.")]
    public string Descripcion { get; set; }
    [Range(0, float.MaxValue, ErrorMessage = "Es obligatorio introducir la cantidad de servicios.")]
    public int CantidadServicios { get; set; }
    [Range(0.01, float.MaxValue, ErrorMessage = "Es obligatorio introducir el monto.")]
    public decimal Monto { get; set; }
    public Tecnicos? Tecnicos { get; set; }
}

