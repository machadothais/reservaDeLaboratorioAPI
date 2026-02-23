using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace reservaDeLaboratorioAPI.Models;

public class LaboratoroPrpfessor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LaboratorioId { get; set; }
    [JsonIgnore]
    public Laboratorio? Laboratorio { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProfessorId { get; set; }
    [JsonIgnore]
    public Professor? Professor { get; set; }
}
