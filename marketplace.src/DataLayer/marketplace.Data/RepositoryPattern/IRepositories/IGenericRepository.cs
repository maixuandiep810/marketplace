using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface IGenericRepository<TEntity, TPKey> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(TPKey id);
        Task<List<TEntity>> GetAllAsync();
        Task<string> AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);


        // void AddRange(IEnumerable<TEntity> entities);
        // void RemoveRange(IEnumerable<TEntity> entities);
    }
}