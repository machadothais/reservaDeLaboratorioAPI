using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Repository;

public interface IProfessor : IRepository<Professor> 
{
    object Professores { get; }

    Task<IEnumerable<Professor>> GetAllAsync();
    Task<Professor?> GetByIdAsync(int id);

    Task AddAsync(Professor entity);
    Task UpdateAsync(Professor entity);
    Task DeleteAsync(int id);

}
