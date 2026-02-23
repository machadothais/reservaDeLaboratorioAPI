using Microsoft.AspNetCore.Mvc;
using reservaDeLaboratorioAPI.Context;
using reservaDeLaboratorioAPI.DTO;
using reservaDeLaboratorioAPI.Extensions;
using reservaDeLaboratorioAPI.Models;
using reservaDeLaboratorioAPI.Repository;

namespace reservaDeLaboratorioAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ContatoController : ControllerBase
{
    private readonly IContato _repository;
    private readonly AppDbContext _context;
    public ContatoController(AppDbContext context  ,IContato repository)
    {
        _repository = repository;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contatos = await _repository.GetAllAsync();
        return Ok(contatos.Select (c=>c.ToDto()));
    }
    [HttpGet]
    [Route("{id:int}", Name = "ObterContato")]
    public async Task<IActionResult> GetById(int id)
    {
        var contato = await _repository.GetByIdAsync(id);
        if (contato == null)
            return NotFound($"Contato com ID {id} não encontrado.");
        return Ok(contato.ToDto());
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ContatoRequestDto request)
    {
        if (request == null)
            return BadRequest("Dados inválidos.");
        var contato = new Contato
        {
            Nome = request.Nome,
            Email = request.Email,
            Mensagem = request.Mensagem
        };
        await _repository.AddAsync(contato);
        return CreatedAtRoute ("ObterContato", new { id = contato.ContatoId }, contato.ToDto());
    }
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ContatoRequestDto request)
    {
        var contatoExistente = await _repository.GetByIdAsync(id);
        if (contatoExistente == null)
            return NotFound($"Contato com ID {id} não encontrado.");
        contatoExistente.Nome = request.Nome;
        contatoExistente.Email = request.Email;
        contatoExistente.Mensagem = request.Mensagem;
        await _repository.UpdateAsync(contatoExistente);
        return Ok(contatoExistente.ToDto());
    }
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var contato = await _repository.GetByIdAsync(id);
        if (contato == null)
            return NotFound($"Contato com ID {id} não encontrado.");
        await _repository.DeleteAsync(id);
        return Ok(contato.ToDto());
        
    }
}
