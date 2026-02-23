using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace reservaDeLaboratorioAPI.Models
{
    public class Professor: IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfessorId { get; set; }

        [Required, MaxLength(120)]
        public string Nome { get; set; } = string.Empty;

        [EmailAddress, MaxLength(180)]
        public string? Email { get; set; }

        [Required]
        [ForeignKey(nameof(Laboratorio))]
        public int LaboratorioId { get; set; }

        [JsonIgnore]
        public Laboratorio? Laboratorio { get; set; }

        [JsonIgnore]
        public ICollection<Turma> Turmas { get; set; } = new HashSet<Turma>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                yield return new ValidationResult(
                    "O nome do professor é obrigatório.",
                    new[] { nameof(Nome) });
            }
            else if (Nome.Length < 3)
            {
                yield return new ValidationResult(
                    "O nome do professor deve ter pelo menos 3 caracteres.",
                    new[] { nameof(Nome) });
            }

            // ⚙️ Validação de e-mail já é feita pelo [EmailAddress]
            // então só valida se for obrigatório no seu contexto:
            if (string.IsNullOrWhiteSpace(Email))
            {
                yield return new ValidationResult(
                    "O email do professor é obrigatório.",
                    new[] { nameof(Email) });
            }
        }

    }
}
