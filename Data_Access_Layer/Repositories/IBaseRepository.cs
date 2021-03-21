using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetEntityAsync(int id);
        Task<IEnumerable<TEntity>>  GetAllEntityAsync();
        Task<TEntity> AddEntityAsync(TEntity entity);
        IEnumerable<TEntity> FindEntity(Expression<Func<TEntity,bool>> predicate);
        Task UpdateEntityAsync(TEntity entityChanges);
        Task UpdateRangeEntityAsync(List<TEntity> boardChangesRange);
        Task DeleteEntityAsync(int id);
    }
}
