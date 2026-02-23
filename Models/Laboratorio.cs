using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace reservaDeLaboratorioAPI.Models
{
    public class Laboratorio : IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LaboratorioId { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Range(1, 2000)]
        public int Capacidade { get; set; }

        [JsonIgnore]
        public ICollection<Professor> Professores { get; set; } = new HashSet<Professor>();

        [JsonIgnore]
        public ICollection<Reserva> Reservas { get; set; } = new HashSet<Reserva>();

        // ✅ Método correto exigido pelo IValidatableObject
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Validação do nome
            if (string.IsNullOrWhiteSpace(Nome))
            {
                yield return new ValidationResult(
                    "O nome do laboratório é obrigatório.",
                    new[] { nameof(Nome) });
            }
            else if (Nome.Length < 3)
            {
                yield return new ValidationResult(
                    "O nome do laboratório deve ter pelo menos 3 caracteres.",
                    new[] { nameof(Nome) });
            }

            // Validação da capacidade
            if (Capacidade <= 0)
            {
                yield return new ValidationResult(
                    "A capacidade do laboratório deve ser um número positivo.",
                    new[] { nameof(Capacidade) });
            }
        }
    }
}
