using Microsoft.EntityFrameworkCore;
using reservaDeLaboratorioAPI.Context;
using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Repository
{
    public class LaboratorioRepository : Ilaboratorio
    {
        private readonly AppDbContext _laboratorioRepository;

        public LaboratorioRepository(AppDbContext laboratorioRepository)
        {
            _laboratorioRepository = laboratorioRepository;
        }

        public async Task<IEnumerable<Laboratorio>> GetAllAsync()
        {
            return await _laboratorioRepository.Laboratorios.ToListAsync();
        }

        public async Task<Laboratorio?> GetByIdAsync(int id)
        {
            return await _laboratorioRepository.Laboratorios.FindAsync(id);
        }

        public async Task AddAsync(Laboratorio entity)
        {
            _laboratorioRepository.Laboratorios.Add(entity);
            await _laboratorioRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Laboratorio entity)
        {
            _laboratorioRepository.Laboratorios.Update(entity);
            await _laboratorioRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var laboratorio = await _laboratorioRepository.Laboratorios.FindAsync(id);
            if (laboratorio != null)
            {
                _laboratorioRepository.Laboratorios.Remove(laboratorio);
                await _laboratorioRepository.SaveChangesAsync();
            }
        }
    }
}
