using Microsoft.AspNetCore.Mvc;
using reservaDeLaboratorioAPI.DTO;
using reservaDeLaboratorioAPI.Extensions;
using reservaDeLaboratorioAPI.Models;
using reservaDeLaboratorioAPI.Repository;

namespace reservaDeLaboratorioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmasController : ControllerBase
    {
        private readonly ITurma _repository;

        public TurmasController(ITurma repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var turmas = await _repository.GetAllAsync();
            if (!turmas.Any())
                return NotFound("Nenhuma turma encontrada.");

            return Ok(turmas.Select(t => t.ToDto()));
        }

        [HttpGet("{id:int}", Name = "ObterTurma")]
        public async Task<IActionResult> GetById(int id)
        {
            var turma = await _repository.GetByIdAsync(id);
            if (turma == null)
                return NotFound($"Turma com ID {id} não encontrada.");

            return Ok(turma.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TurmaRequestDto request)
        {
            if (request == null)
                return BadRequest("Dados inválidos.");

            var turma = new Turma
            {
                Nome = request.Nome,
                QuantidadeAlunos = request.QuantidadeAlunos,
                ProfessorId = request.ProfessorId
            };

            await _repository.AddAsync(turma);
            return CreatedAtRoute("ObterTurma", new { id = turma.TurmaId }, turma.ToDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TurmaRequestDto request)
        {
            var turmaExistente = await _repository.GetByIdAsync(id);
            if (turmaExistente == null)
                return NotFound($"Turma com ID {id} não encontrada.");

            turmaExistente.Nome = request.Nome;
            turmaExistente.QuantidadeAlunos = request.QuantidadeAlunos;
            turmaExistente.ProfessorId = request.ProfessorId;

            await _repository.UpdateAsync(turmaExistente);
            return Ok(new { Mensagem = "Turma atualizada com sucesso.", turma = turmaExistente.ToDto() });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var turma = await _repository.GetByIdAsync(id);
            if (turma == null)
                return NotFound($"Turma com ID {id} não encontrada.");

            await _repository.DeleteAsync(id);
            return Ok(new { Mensagem = $"Turma com ID {id} excluída com sucesso." });
        }
    }
}
