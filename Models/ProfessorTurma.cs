using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace reservaDeLaboratorioAPI.Models;

public class ProfessorTurma
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProfessorId { get; set; }
    [JsonIgnore]
    public Professor? Professor { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TurmaId { get; set; }
    [JsonIgnore]
    public Turma? Turma { get; set; }
}
