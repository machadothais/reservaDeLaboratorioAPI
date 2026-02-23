using System.ComponentModel.DataAnnotations;

namespace reservaDeLaboratorioAPI.DTO;

public class LaboratorioRequestDto
{
    [Required(ErrorMessage = "O nome do laboratório é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Range(1, 200, ErrorMessage = "A capacidade deve ser entre 1 e 200.")]
    public int Capacidade { get; set; }
}
