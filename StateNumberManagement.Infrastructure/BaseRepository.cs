using Microsoft.EntityFrameworkCore;
using StateNumberManagement.Domain;

namespace StateNumberManagement.Infrastructure
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _table;

        protected IQueryable<T> Table 
        { 
            get 
            { 
                return _table; 
            } 
        }

        public BaseRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken token)
        {
            await _table.AddAsync(entity, token);

            await _context.SaveChangesAsync(token);
        }

        public abstract Task<T> GetAsync(string Id, CancellationToken token);
        
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken token) 
        {
            return _table;
        }

        public async Task UpdateAsync(T entity, CancellationToken token)
        {
            _table.Update(entity);

            await _context.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(string Id, CancellationToken token)
        {
            _table.Remove(await GetAsync(Id, token));

            await _context.SaveChangesAsync(token);
        }
    }
}
