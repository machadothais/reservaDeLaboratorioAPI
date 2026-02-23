using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace reservaDeLaboratorioAPI.Models
{
    public class Turma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TurmaId { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Range(1, 2000)]
        public int QuantidadeAlunos { get; set; }

        [Required]
        [ForeignKey(nameof(Professor))]
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; } = null!;

        [JsonIgnore]
        public ICollection<Reserva> Reservas { get; set; } = new HashSet<Reserva>();
    }
}
