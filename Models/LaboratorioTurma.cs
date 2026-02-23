using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace reservaDeLaboratorioAPI.Models;

public class LaboratorioTurma
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LaboratorioId { get; set; }
    [JsonIgnore]
    public Laboratorio? Laboratorio { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TurmaId { get; set; }
    [JsonIgnore]
    public Turma? Turma { get; set; }
}
