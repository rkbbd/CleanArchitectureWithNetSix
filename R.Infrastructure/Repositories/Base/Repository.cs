using Microsoft.EntityFrameworkCore;
using R.Core.Repositories.Base;
using R.Infrastructure.Data;

namespace R.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PersonContext _personContext;
        public Repository(PersonContext employeeContext)
        {
            _personContext = employeeContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _personContext.Set<T>().AddAsync(entity);
            await _personContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _personContext.Set<T>().Remove(entity);
            await _personContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _personContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _personContext.Set<T>().FindAsync(id);
        }
        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
