using System.ComponentModel.DataAnnotations;

namespace sithecAPI.Models.Entities
{
    public class Humano
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La EDAD debe de ser mayor a 0.")]
        public int Edad { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage ="La ALTURA debe de ser mayor a 0.")]
        public double Altura { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "El PESO debe de ser mayor a 0.")]
        public double Peso { get; set; }
    }
}
