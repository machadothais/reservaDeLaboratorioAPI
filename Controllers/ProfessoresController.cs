using Microsoft.AspNetCore.Mvc;
using reservaDeLaboratorioAPI.DTO;
using reservaDeLaboratorioAPI.Extensions;
using reservaDeLaboratorioAPI.Models;
using reservaDeLaboratorioAPI.Repository;

namespace reservaDeLaboratorioAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessoresController : ControllerBase
{
    private readonly IProfessor _professorRepository;

    public ProfessoresController(IProfessor professorRepository)
    {
        _professorRepository = professorRepository;
    }

    // ✅ Método GET - Retorna todos os professores com o nome do laboratório
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var professores = await _professorRepository.GetAllAsync();
        if (professores == null || !professores.Any())
            return NotFound("Nenhum professor encontrado.");

        return Ok(professores.Select(p => p.ToDto()));
    }

    // ✅ Método GET por ID
    [HttpGet("{id:int}", Name = "ObterProfessor")]
    public async Task<IActionResult> GetById(int id)
    {
        var professor = await _professorRepository.GetByIdAsync(id);
        if (professor == null)
            return NotFound($"Professor com ID {id} não encontrado.");

        return Ok(professor.ToDto());
    }

    // ✅ Método POST
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProfessorRequestDto request)
    {
        if (request == null)
            return BadRequest("Dados inválidos.");

        var professor = new Professor
        {
            Nome = request.Nome,
            Email = request.Email,
            LaboratorioId = request.LaboratorioId
        };

        await _professorRepository.AddAsync(professor);

        return CreatedAtRoute("ObterProfessor", new { id = professor.ProfessorId }, professor.ToDto());
    }

    // ✅ Método PUT
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProfessorRequestDto request)
    {
        var professorExistente = await _professorRepository.GetByIdAsync(id);
        if (professorExistente == null)
            return NotFound($"Professor com ID {id} não encontrado.");

        professorExistente.Nome = request.Nome;
        professorExistente.Email = request.Email;
        professorExistente.LaboratorioId = request.LaboratorioId;

        await _professorRepository.UpdateAsync(professorExistente);

        return Ok(new
        {
            Mensagem = "Professor atualizado com sucesso.",
            professor = professorExistente.ToDto()
        });
    }

    // ✅ Método DELETE
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var professor = await _professorRepository.GetByIdAsync(id);
        if (professor == null)
            return NotFound($"Professor com ID {id} não encontrado.");

        await _professorRepository.DeleteAsync(id);
        return Ok(new { Mensagem = $"Professor com ID {id} excluído com sucesso." });
    }
}
