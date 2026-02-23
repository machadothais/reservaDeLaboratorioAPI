using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Repository
{
    public interface IReserva
    {
        Task<IEnumerable<Reserva>> GetAllAsync();
        Task<Reserva?> GetByIdAsync(int id);
        Task AddAsync(Reserva entity);
        Task UpdateAsync(Reserva entity);
        Task DeleteAsync(int id);
    }
}
