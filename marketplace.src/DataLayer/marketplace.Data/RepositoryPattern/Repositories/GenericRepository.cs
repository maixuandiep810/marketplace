using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.EF;
using marketplace.Data.Entities;
using System.Linq.Expressions;
using System.Linq;
using marketplace.Utilities.Const;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public abstract class GenericRepository<TEntity, TPKey> : IGenericRepository<TEntity, TPKey> where TEntity : class, IBaseEntity<TPKey>
    {
        protected readonly marketplaceDbContext _context;
        protected readonly DbSet<TEntity> entities;

        public GenericRepository(marketplaceDbContext context)
        {
            _context = context;
            entities = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(TPKey id)
        {
            try
            {
                return await entities.FindAsync(id);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await entities.ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddAsync(TEntity entity)
        {
            try
            {
                var result = await entities.AddAsync(entity);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                entities.Update(entity);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(TEntity entity)
        {
            try
            {
                entities.Remove(entity);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var query = entities.Where(predicate).AsQueryable();
                return query;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var query = Find(predicate);
                var result = await query.FirstOrDefaultAsync<TEntity>();
                return result;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

    }
}