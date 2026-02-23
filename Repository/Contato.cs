using Microsoft.EntityFrameworkCore;
using reservaDeLaboratorioAPI.Context;
using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Repository
{
    public class ContatoRepository : IContato
    {
        private readonly AppDbContext _contatoRepository;

        public ContatoRepository(AppDbContext contatoRepository)
        {
            _contatoRepository= contatoRepository;
        }

        public async Task AddAsync(Contato entity)
        {
            await _contatoRepository.Contatos.AddAsync(entity);
            await _contatoRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contato = await _contatoRepository.Contatos.FindAsync(id);
            if (contato != null)
            {
                _contatoRepository.Contatos.Remove(contato);
                await _contatoRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Contato>> GetAllAsync()
        {
            // ✅ uso correto do EF Core para consulta assíncrona
            return await _contatoRepository.Contatos.ToListAsync();
        }

        public async Task<Contato?> GetByIdAsync(int id)
        {
            return await _contatoRepository.Contatos.FindAsync(id);
        }

        public async Task UpdateAsync(Contato entity)
        {
            _contatoRepository.Entry(entity).State = EntityState.Modified;
            await _contatoRepository.SaveChangesAsync();
        }

    }
}
