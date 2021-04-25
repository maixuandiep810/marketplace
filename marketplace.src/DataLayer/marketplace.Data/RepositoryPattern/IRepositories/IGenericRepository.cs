using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface IGenericRepository<TEntity, TPKey> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(TPKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<int> AddAsync(TEntity entity);
        int Update(TEntity entity);
        void Delete(TEntity entity);

        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        
        // TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        // void AddRange(IEnumerable<TEntity> entities);
        // void RemoveRange(IEnumerable<TEntity> entities);
    }
}