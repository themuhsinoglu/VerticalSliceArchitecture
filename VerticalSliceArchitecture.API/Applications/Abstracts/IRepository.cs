using System.Linq.Expressions;

namespace VerticalSliceArchitecture.API.Applications.Abstracts
{
    public interface IRepository<TEntity>   
    {
        ValueTask<TEntity?> GetByIdAsync(int id);
        Task<IList<TEntity>> GetAllAsync();
        Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task RemoveById(int id);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void UntrackEntity(TEntity entity);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
