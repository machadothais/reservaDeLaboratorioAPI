using System.ComponentModel.DataAnnotations;

namespace reservaDeLaboratorioAPI.DTO;

public class ProfessorRequestDto
{
    [Required(ErrorMessage = "O nome do professor é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O ID do laboratório é obrigatório.")]
    public int LaboratorioId { get; set; }
}
