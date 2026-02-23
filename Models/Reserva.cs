using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace reservaDeLaboratorioAPI.Models
{
    public class Reserva : IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservaId { get; set; }

        [Required]
        public int LaboratorioId { get; set; }

        [Required]
        public int TurmaId { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        [MaxLength(255)]
        public string Observacao { get; set; } = string.Empty;

        // 🔹 Relações
        [ForeignKey("LaboratorioId")]
        public Laboratorio? Laboratorio { get; set; }

        [ForeignKey("TurmaId")]
        public Turma? Turma { get; set; }

        public Professor? Professor { get; set; }

        // ✅ Validações personalizadas
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // 🔸 1. Datas obrigatórias
            if (DataInicio == default)
                yield return new ValidationResult("A data de início deve ser informada.", new[] { nameof(DataInicio) });

            if (DataFim == default)
                yield return new ValidationResult("A data de término deve ser informada.", new[] { nameof(DataFim) });

            // 🔸 2. A data de início não pode ser posterior à data de fim
            if (DataInicio > DataFim)
                yield return new ValidationResult("A data de início não pode ser posterior à data de término.", new[] { nameof(DataInicio), nameof(DataFim) });

            // 🔸 3. Duração mínima de 1 minuto
            if ((DataFim - DataInicio).TotalMinutes < 1)
                yield return new ValidationResult("A reserva deve ter pelo menos 1 minuto de duração.", new[] { nameof(DataInicio), nameof(DataFim) });

            // 🔸 4. Não permitir datas passadas
            if (DataInicio < DateTime.Now.AddMinutes(-5))
                yield return new ValidationResult("A data de início não pode estar no passado.", new[] { nameof(DataInicio) });

            // 🔸 5. Duração máxima (exemplo: 12h)
            if ((DataFim - DataInicio).TotalHours > 12)
                yield return new ValidationResult("A reserva não pode exceder 12 horas de duração.", new[] { nameof(DataFim) });
        }

    }
}
