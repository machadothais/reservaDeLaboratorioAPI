namespace reservaDeLaboratorioAPI.DTO;

public class LaboratorioResponseDto
{
    public int LaboratorioId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Capacidade { get; set; }
}
