using Microsoft.EntityFrameworkCore;
using reservaDeLaboratorioAPI.Context;

namespace reservaDeLaboratorioAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _repository; // ✅ renomeado, mas tipo correto

        public Repository(AppDbContext repository)
        {
            _repository = repository; // ✅ injetado corretamente
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _repository.Set<T>().AddAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Entry(entity).State = EntityState.Modified;
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _repository.Set<T>().Remove(entity);
                await _repository.SaveChangesAsync();
            }
        }

       
    }
}
