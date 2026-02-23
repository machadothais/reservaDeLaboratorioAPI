using reservaDeLaboratorioAPI.DTO;
using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Extensions;

public static class ProfessorExtensions
{

    public static ProfessorResponseDto ToDto(this Professor professor)
    {
        if (professor == null)
            throw new ArgumentNullException(nameof(professor));

        return new ProfessorResponseDto
        {
            ProfessorId = professor.ProfessorId,
            Nome = professor.Nome,
            Email = professor.Email,
            LaboratorioId = professor.LaboratorioId,
            NomeLaboratorio = professor.Laboratorio?.Nome ?? string.Empty
        };
    }
}
