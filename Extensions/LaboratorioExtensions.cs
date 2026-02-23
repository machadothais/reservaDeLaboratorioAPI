using reservaDeLaboratorioAPI.DTO;
using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Extensions;

public static class LaboratorioExtensions
{
    public static LaboratorioResponseDto ToDto(this Laboratorio laboratorio)
    {
        if (laboratorio == null)
            throw new ArgumentNullException(nameof(laboratorio));

        return new LaboratorioResponseDto
        {
            LaboratorioId = laboratorio.LaboratorioId,
            Nome = laboratorio.Nome,
            Capacidade = laboratorio.Capacidade
        };
    }
}
