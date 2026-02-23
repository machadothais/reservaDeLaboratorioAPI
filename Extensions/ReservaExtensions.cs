using reservaDeLaboratorioAPI.DTO;
using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Extensions;

public static class ReservaExtensions
{
    public static ReservaResponseDto ToDto(this Reserva reserva)
    {
        if (reserva == null)
            throw new ArgumentNullException(nameof(reserva));

        return new ReservaResponseDto
        {
            ReservaId = reserva.ReservaId,
            LaboratorioId = reserva.LaboratorioId,
            TurmaId = reserva.TurmaId,
            DataInicio = reserva.DataInicio,
            DataFim = reserva.DataFim,
            Observacao = reserva.Observacao,
            NomeLaboratorio = reserva.Laboratorio?.Nome ?? string.Empty,
            NomeTurma = reserva.Turma?.Nome ?? string.Empty
        };
    }
}
