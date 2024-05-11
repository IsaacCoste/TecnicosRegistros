using System.ComponentModel.DataAnnotations;

namespace TecnicosRegistros.Models
{
    public class Tecnicos
    {
        [Key]
        public int TecnicoId { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten letras.")]
        [Required(ErrorMessage = "Es obligatorio introducir el Nombre del técnico.")]
        public string Nombres { get; set; }
        [Range(0.01, float.MaxValue, ErrorMessage = "Es obligatorio introducir el SueldoHora")]
        public decimal SueldoHora { get; set; }
    }
}