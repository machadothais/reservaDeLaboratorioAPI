using reservaDeLaboratorioAPI.Context;
using reservaDeLaboratorioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace reservaDeLaboratorioAPI.Repository;
public class TurmaRepository : ITurma
{
    private readonly AppDbContext _turmaRepository;
    public TurmaRepository(AppDbContext turmaRepository)
    {
        _turmaRepository = turmaRepository;
    }
   

      
        public async Task<IEnumerable<Turma>> GetAllAsync()
        {
            return await _turmaRepository.Turmas
                .Include(t => t.Professor)
                .ToListAsync();
        }

        public async Task<Turma?> GetByIdAsync(int id)
        {
            return await _turmaRepository.Turmas
                .Include(t => t.Professor)
                .FirstOrDefaultAsync(t => t.TurmaId == id);
        }

        public async Task AddAsync(Turma entity)
        {
            _turmaRepository.Turmas.Add(entity);
            await _turmaRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Turma entity)
        {
            _turmaRepository.Turmas.Update(entity);
            await _turmaRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var turma = await _turmaRepository.Turmas.FindAsync(id);
            if (turma != null)
            {
                _turmaRepository.Turmas.Remove(turma);
                await _turmaRepository.SaveChangesAsync();
            }
        }
    }




