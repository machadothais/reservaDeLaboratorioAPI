using System.ComponentModel.DataAnnotations;

namespace reservaDeLaboratorioAPI.DTO;

public class TurmaRequestDto
{
    [Required(ErrorMessage = "O nome da turma é obrigatório.")]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Range(1, 200, ErrorMessage = "A quantidade de alunos deve ser entre 1 e 200.")]
    public int QuantidadeAlunos { get; set; }

    [Required(ErrorMessage = "O ID do professor é obrigatório.")]
    public int ProfessorId { get; set; }
}
