using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiVoucher.BaseService
{
    public interface IBaseService<TEntity>
        where TEntity : class
    {
        int Count();
        TEntity Get<TKey>(TKey id);
        Task<TEntity> GetAsyn<TKey>(TKey id);
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault();
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsyn();
        Task<TEntity> FirstOrDefaultAsyn(Expression<Func<TEntity, bool>> predicate);
        TEntity Create(TEntity entity);
        Task CreateAsyn(TEntity entity);
        public TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAsyn(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsyn(IEnumerable<TEntity> entities);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task RemoveRangeAsyn(IEnumerable<TEntity> entities);
        TEntity GetAvaiableObjectById(int Id);
        Boolean Save();
        Task SaveAsyn();
        TEntity DeleteOne(int id);
    }
}
