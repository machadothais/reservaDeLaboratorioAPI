using reservaDeLaboratorioAPI.Context;
using reservaDeLaboratorioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace reservaDeLaboratorioAPI.Repository
{
    public class ProfessorRepository : IProfessor
    {
        private readonly AppDbContext _context;

        public ProfessorRepository(AppDbContext context)
        {
            _context = context;
        }

        public object Professores => throw new NotImplementedException();

        public async Task AddAsync(Professor entity)
        {
            _context.Professores.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            if (professor != null)
            {
                _context.Professores.Remove(professor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Professor>> GetAllAsync()
        {
            // 🔹 Inclui o relacionamento com Laboratório
            return await _context.Professores
                .Include(p => p.Laboratorio)
                .ToListAsync();
        }

        public async Task<Professor?> GetByIdAsync(int id)
        {
            // 🔹 Inclui o relacionamento com Laboratório
            return await _context.Professores
                .Include(p => p.Laboratorio)
                .FirstOrDefaultAsync(p => p.ProfessorId == id);
        }

        public async Task UpdateAsync(Professor entity)
        {
            _context.Professores.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
