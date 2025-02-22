using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace Hakathon.infrastructure
{
    public class BaseRepository<T> where T : class
    {

        protected readonly DbContext _context;

        protected readonly DbSet<T> _dbSet;



        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> GetAsync(CancellationToken token, params object[] key)
        {
            return await _dbSet.FindAsync(key, token);
        }
        public async Task AddAsync(CancellationToken token, T entity)
        {
            await _dbSet.AddAsync(entity, token);
            await _context.SaveChangesAsync(token);
        }
        public async Task UpdateAsync(CancellationToken token, T entity)
        {
            if (entity == null)
                return;

            _dbSet.Update(entity);
            await _context.SaveChangesAsync(token);
        }
        public async Task RemoveAsync(CancellationToken token, params object[] key)
        {
            var entity = await GetAsync(token, key);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(token);
        }
        public async Task RemoveAsync(CancellationToken token, T entity)
        {
            if (entity == null)
                return;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(token);
        }
        public async Task<bool> AnyAsync(CancellationToken token, Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate, token);
        }
    }
}
