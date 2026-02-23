namespace reservaDeLaboratorioAPI.DTO;

public class TurmaResponseDto
{
    public int TurmaId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int QuantidadeAlunos { get; set; }
    public int ProfessorId { get; set; }
}
