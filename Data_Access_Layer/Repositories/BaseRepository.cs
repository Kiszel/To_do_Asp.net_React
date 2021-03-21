using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Data_Access_Layer.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext;
        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<TEntity> AddEntityAsync(TEntity entity)
        {
            _dataContext.Set<TEntity>().Add(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntityAsync(int id)
        {
            var entity = _dataContext.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _dataContext.Set<TEntity>().Remove(entity);
                await _dataContext.SaveChangesAsync();
            }
        }

        public IEnumerable<TEntity> FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataContext.Set<TEntity>().Where(predicate);
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllEntityAsync()
        {
            var entities = await _dataContext.Set<TEntity>().ToListAsync();
            return entities;
        }

        public async Task<TEntity> GetEntityAsync(int id)
        {
            var entity = await _dataContext.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public async Task UpdateEntityAsync(TEntity entityChanges)
        {
            _dataContext.Set<TEntity>().Update(entityChanges);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateRangeEntityAsync(List<TEntity> entityChangesRange)
        {
            _dataContext.Set<TEntity>().UpdateRange(entityChangesRange);
            await _dataContext.SaveChangesAsync();
        }

    }
}
