using Microsoft.EntityFrameworkCore;
using reservaDeLaboratorioAPI.Context;
using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Repository
{
    public class ReservaRepository : IReserva
    {
        private readonly AppDbContext _context;

        public ReservaRepository(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 Adiciona uma reserva
        public async Task AddAsync(Reserva entity)
        {
            _context.Reservas.Add(entity);
            await _context.SaveChangesAsync();
        }

        // 🔹 Atualiza uma reserva existente
        public async Task UpdateAsync(Reserva entity)
        {
            _context.Reservas.Update(entity);
            await _context.SaveChangesAsync();
        }

        // 🔹 Exclui uma reserva
        public async Task DeleteAsync(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
        }

        // 🔹 Retorna todas as reservas com Laboratório e Turma (INCLUDE)
        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            return await _context.Reservas
                .Include(r => r.Laboratorio)
                .Include(r => r.Turma)
                .ToListAsync();
        }

        // 🔹 Retorna reserva específica com relacionamentos
        public async Task<Reserva?> GetByIdAsync(int id)
        {
            return await _context.Reservas
                .Include(r => r.Laboratorio)
                .Include(r => r.Turma)
                .FirstOrDefaultAsync(r => r.ReservaId == id);
        }
    }
}
