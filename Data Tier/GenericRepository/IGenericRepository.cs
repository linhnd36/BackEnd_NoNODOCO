using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data_Tier.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
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
        EntityEntry<TEntity> Create(TEntity entity);
        Task CreateAsyn(TEntity entity);
        EntityEntry<TEntity> Delete(TEntity entity);
        EntityEntry<TEntity> Update(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsyn(IEnumerable<TEntity> entities);
        void RemoveRange(IEnumerable<TEntity> entities);
        IQueryable<TEntity> FromSqlRaw(string sql);
        List<TEntity> FromSqlRawList(string sql);
        IQueryable<TEntity> FromSqlRawByTEntity(String sql, SqlParameter[] parameters);
    }
}
