using reservaDeLaboratorioAPI.DTO;
using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Extensions;


public static class TurmaExtensions
{
    public static TurmaResponseDto ToDto(this Turma turma)
    {
        if (turma == null)
            throw new ArgumentNullException(nameof(turma));

        return new TurmaResponseDto
        {
            TurmaId = turma.TurmaId,
            Nome = turma.Nome,
            QuantidadeAlunos = turma.QuantidadeAlunos,
            ProfessorId = turma.ProfessorId
        };
    }
}