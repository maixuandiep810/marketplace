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
using marketplace.Data.Enums;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public abstract class GenericRepository<TEntity, TPKey> : IGenericRepository<TEntity, TPKey> where TEntity : class, IBaseEntity<TPKey>
    {
        protected readonly marketplaceDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public GenericRepository(marketplaceDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(TPKey id)
        {
            return await _entities.FindAsync(id);
            // try
            // {
            //     return await _entities.FindAsync(id);
            // }
            // catch (System.Exception ex)
            // {
            //     throw ex;
            // }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();

            // try
            // {
            //     return await _entities.ToListAsync();
            // }
            // catch (System.Exception ex)
            // {
            //     throw ex;
            // }
        }

        public async Task<string> AddAsync(TEntity entity)
        {
            var result = await _entities.AddAsync(entity);
            return entity.Id.ToString();

            // try
            // {
            //     var result = await _entities.AddAsync(entity);
            //     return entity.Id.ToString();
            // }
            // catch (System.Exception ex)
            // {
            //     throw ex;
            // }
        }

        public void Update(TEntity entity)
        {

            _entities.Update(entity);

            // try
            // {
            //     _entities.Update(entity);
            // }
            // catch (System.Exception ex)
            // {
            //     throw ex;
            // }
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);

            // try
            // {
            //     _entities.Remove(entity);
            // }
            // catch (System.Exception ex)
            // {
            //     throw ex;
            // }
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var query = _entities.Where(predicate).AsQueryable();
            return query;
            // try
            // {
            //     var query = _entities.Where(predicate).AsQueryable();
            //     return query;
            // }
            // catch (System.Exception ex)
            // {
            //     throw ex;
            // }
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = Find(predicate);
            var result = await query.FirstOrDefaultAsync<TEntity>();
            return result;

            // try
            // {
            //     var query = Find(predicate);
            //     var result = await query.FirstOrDefaultAsync<TEntity>();
            //     return result;
            // }
            // catch (System.Exception ex)
            // {
            //     throw ex;
            // }
        }

        public void DeactivateEntity(TEntity entity)
        {
            entity.TrangThai = TrangThai.KhongHoatDong;
        }

        public void ActivateEntity(TEntity entity)
        {
            entity.TrangThai = TrangThai.HoatDong;
        }

        public void DeleteEntity(TEntity entity)
        {
            entity.DaXoa = true;
        }

        public async Task<List<TEntity>> GetAllDeletedEntityAsync()
        {
            var deletedEntities = await _entities.Where(x => x.DaXoa == true).ToListAsync();
            return deletedEntities;
        }

        public void DeleteDataAllDeletedEntity(List<TEntity> deletedEntities)
        {
            if (deletedEntities == null)
            {
                return;
            }
            _entities.RemoveRange(deletedEntities);
        }

        public async Task<int> CountRecordAsync()
        {
            return await _entities.CountAsync();
        }

        public async Task<List<TEntity>> GetPageByIdAsync(int start, int limit)
        {
            return await _entities.Select(x => x).OrderByDescending(x => x.Id).Skip(start).Take(limit).ToListAsync();
        }
    }
}