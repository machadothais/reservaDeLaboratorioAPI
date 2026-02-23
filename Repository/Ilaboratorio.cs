using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Repository;

public interface Ilaboratorio: IRepository<Laboratorio>
{
    Task<IEnumerable<Laboratorio>> GetAllAsync();
    Task<Laboratorio?> GetByIdAsync(int id);
    Task AddAsync(Laboratorio entity);
    Task UpdateAsync(Laboratorio entity);
    Task DeleteAsync(int id);
}
