using System.Linq; // necessário se não houver global usings
using Microsoft.AspNetCore.Mvc;
using reservaDeLaboratorioAPI.DTO;
using reservaDeLaboratorioAPI.Extensions; // para ToDto()
using reservaDeLaboratorioAPI.Models;
using reservaDeLaboratorioAPI.Repository;

namespace reservaDeLaboratorioAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LaboratoriosController : ControllerBase
{
    private readonly Ilaboratorio _repository;

    public LaboratoriosController(Ilaboratorio repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var laboratorios = await _repository.GetAllAsync();
        if (laboratorios == null || !laboratorios.Any())
            return NotFound("Nenhum laboratório encontrado.");

        return Ok(laboratorios.Select(l => l.ToDto()));
    }

    [HttpGet("{id:int}", Name = "ObterLaboratorio")]
    public async Task<IActionResult> GetById(int id)
    {
        var laboratorio = await _repository.GetByIdAsync(id);
        if (laboratorio == null)
            return NotFound($"Laboratório com ID {id} não encontrado.");

        return Ok(laboratorio.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] LaboratorioRequestDto request)
    {
        if (request == null)
            return BadRequest("Dados inválidos.");

        var laboratorio = new Laboratorio
        {
            Nome = request.Nome,
            Capacidade = request.Capacidade
        };

        await _repository.AddAsync(laboratorio);
        return CreatedAtRoute("ObterLaboratorio",
            new { id = laboratorio.LaboratorioId },
            laboratorio.ToDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] LaboratorioRequestDto request)
    {
        if (request == null)
            return BadRequest("Dados inválidos.");

        var laboratorioExistente = await _repository.GetByIdAsync(id);
        if (laboratorioExistente == null)
            return NotFound($"Laboratório com ID {id} não encontrado.");

        laboratorioExistente.Nome = request.Nome;
        laboratorioExistente.Capacidade = request.Capacidade;

        await _repository.UpdateAsync(laboratorioExistente);
        return Ok(new
        {
            Mensagem = "Laboratório atualizado com sucesso.",
            laboratorio = laboratorioExistente.ToDto()
        });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var laboratorio = await _repository.GetByIdAsync(id);
        if (laboratorio == null)
            return NotFound($"Laboratório com ID {id} não encontrado.");

        await _repository.DeleteAsync(id);
        return Ok(new { Mensagem = $"Laboratório com ID {id} excluído com sucesso." });
    }
}
