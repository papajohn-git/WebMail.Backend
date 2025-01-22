using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebMail.Infrastructure.Data;
using WebMail.Infrastructure.Repositories.Interfaces;

namespace WebMail.Infrastructure.Repositories.Implementations
{
    /// <summary>
    /// Generic Repository for Database Operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class GenericRepository<TEntity> : IGenericInterface<TEntity> where TEntity : class
    {
        protected readonly AppDbContext context;
        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
            => await dbSet.AddAsync(entity);

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
            => await dbSet.AddRangeAsync(entities);

        public Task UpdateAsync(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            TEntity? entity = await GetAsync(id);
            if (entity is null) return false;
            dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<TEntity?> GetAsync(int id)
            => await dbSet.FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
            => await dbSet.ToListAsync();

        public virtual async Task<int> GetCountAsync()
            => await dbSet.CountAsync();

        public async Task<IEnumerable<TEntity>> GetAllByPredicateAsync(Expression<Func<TEntity, bool>> predicate)
            => await dbSet.Where(predicate).ToListAsync();
    }
}
