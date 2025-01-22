using System.Linq.Expressions;

namespace WebMail.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    ///  Generic Interface for Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericInterface<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
		Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetAsync(int id);
        Task<int> GetCountAsync();
        Task<IEnumerable<TEntity>> GetAllByPredicateAsync(Expression<Func<TEntity, bool>> Predicate);
    }
}
