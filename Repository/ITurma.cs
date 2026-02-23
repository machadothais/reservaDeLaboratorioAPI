using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Repository;

public interface ITurma: IRepository<Turma>
{
    Task<IEnumerable<Turma>> GetAllAsync();
    Task<Turma?> GetByIdAsync(int id);
    Task AddAsync(Turma entity);
    Task UpdateAsync(Turma entity);
    Task DeleteAsync(int id);
}
