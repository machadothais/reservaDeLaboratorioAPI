using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reservaDeLaboratorioAPI.Context;
using reservaDeLaboratorioAPI.DTO;
using reservaDeLaboratorioAPI.Extensions;
using reservaDeLaboratorioAPI.Models;
using reservaDeLaboratorioAPI.Repository;

namespace reservaDeLaboratorioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IReserva _reservaRepository;
        private readonly AppDbContext _context;

        public ReservasController(IReserva reservaRepository, AppDbContext context)
        {
            _reservaRepository = reservaRepository;
            _context = context;
        }

        // ✅ GET: api/reservas
        [HttpGet]
        public async Task<IActionResult> GetAllReservas()
        {
            var reservas = await _reservaRepository.GetAllAsync();

            if (reservas == null || !reservas.Any())
                return NotFound("Nenhuma reserva encontrada.");

            var reservasDto = reservas.Select(r => r.ToDto());
            return Ok(reservasDto);
        }

        // ✅ GET: api/reservas/{id}
        [HttpGet("{id:int}", Name = "ObterReserva")]
        public async Task<IActionResult> GetReservaById(int id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);

            if (reserva == null)
                return NotFound($"Reserva com ID {id} não encontrada.");

            return Ok(reserva.ToDto());
        }

        // ✅ POST: api/reservas
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservaRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dataInicio = request.DataInicio;
            var dataFim = request.DataFim;

            // 🔹 Busca laboratório e turma pelos nomes
            var laboratorio = await _context.Laboratorios
                .FirstOrDefaultAsync(l => l.Nome == request.NomeLaboratorio);
            if (laboratorio == null)
                return NotFound($"Laboratório '{request.NomeLaboratorio}' não encontrado.");

            var turma = await _context.Turmas
                .FirstOrDefaultAsync(t => t.Nome == request.NomeTurma);
            if (turma == null)
                return NotFound($"Turma '{request.NomeTurma}' não encontrada.");

            // 🔹 Cria e salva a reserva
            var reserva = new Reserva
            {
                LaboratorioId = laboratorio.LaboratorioId,
                TurmaId = turma.TurmaId,
                DataInicio = dataInicio,
                DataFim = dataFim,
                Observacao = request.Observacao ?? string.Empty
            };

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return Ok("Reserva criada com sucesso!");
        }

        // ✅ PUT: api/reservas/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateReserva(int id, [FromBody] ReservaRequestDto request)
        {
            if (request == null)
                return BadRequest("Dados inválidos.");

            var reservaExistente = await _reservaRepository.GetByIdAsync(id);
            if (reservaExistente == null)
                return NotFound($"Reserva com ID {id} não encontrada.");

            var dataInicio = request.DataInicio;
            var dataFim = request.DataFim;

            if (dataInicio > dataFim)
                return BadRequest("A data de início não pode ser posterior à data de término.");

            if ((dataFim - dataInicio).TotalMinutes < 1)
                return BadRequest("A reserva deve ter pelo menos 1 minuto de duração.");

            // 🔹 Busca laboratório e turma pelos nomes
            var laboratorio = await _context.Laboratorios
                .FirstOrDefaultAsync(l => l.Nome == request.NomeLaboratorio);
            if (laboratorio == null)
                return NotFound($"Laboratório '{request.NomeLaboratorio}' não encontrado.");

            var turma = await _context.Turmas
                .FirstOrDefaultAsync(t => t.Nome == request.NomeTurma);
            if (turma == null)
                return NotFound($"Turma '{request.NomeTurma}' não encontrada.");

            // 🔹 Atualiza a reserva
            reservaExistente.LaboratorioId = laboratorio.LaboratorioId;
            reservaExistente.TurmaId = turma.TurmaId;
            reservaExistente.DataInicio = dataInicio;
            reservaExistente.DataFim = dataFim;
            reservaExistente.Observacao = request.Observacao ?? string.Empty;

            try
            {
                await _reservaRepository.UpdateAsync(reservaExistente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar reserva: {ex.Message}");
            }

            return Ok(new
            {
                Mensagem = $"Reserva com ID {id} atualizada com sucesso.",
                Reserva = reservaExistente.ToDto()
            });
        }

        // ✅ DELETE: api/reservas/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var reservaExistente = await _reservaRepository.GetByIdAsync(id);
            if (reservaExistente == null)
                return NotFound($"Reserva com ID {id} não encontrada.");

            try
            {
                await _reservaRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir reserva: {ex.Message}");
            }

            return Ok(new
            {
                Mensagem = $"Reserva com ID {id} excluída com sucesso."
            });
        }
    }
}
