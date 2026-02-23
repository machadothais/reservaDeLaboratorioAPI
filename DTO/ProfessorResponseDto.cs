namespace reservaDeLaboratorioAPI.DTO;

public class ProfessorResponseDto
{
    public int ProfessorId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // 🔹 Referência ao laboratório do professor
    public int LaboratorioId { get; set; }
    public string NomeLaboratorio { get; set; } = string.Empty;
}
