namespace reservaDeLaboratorioAPI.DTO;

public class ReservaResponseDto
{
    // Identificadores
    public int ReservaId { get; set; }
    public int LaboratorioId { get; set; }
    public int TurmaId { get; set; }

    // Dados principais
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string? Observacao { get; set; }

    // Propriedades de exibição (opcional)
    public string NomeLaboratorio { get; set; } = string.Empty;
    public string NomeTurma { get; set; } = string.Empty;
}
