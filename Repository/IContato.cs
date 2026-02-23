using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Repository
{
    public interface IContato : IRepository<Contato>
    {
        // Aqui você pode declarar métodos específicos do Contato, se quiser.
        // Exemplo:
        // Task<IEnumerable<Contato>> BuscarPorEmailAsync(string email);
    }
}
