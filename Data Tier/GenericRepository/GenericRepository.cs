
using Data_Tier.DBContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data_Tier.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected NoNODOCOContext _context;
        protected DbSet<TEntity> dbSet = null;

        public GenericRepository(NoNODOCOContext context)
        {
            this._context = context;
            this.dbSet = _context.Set<TEntity>();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public async Task AddRangeAsyn(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public int Count()
        {
            return dbSet.Count();
        }

        public EntityEntry<TEntity> Create(TEntity entity)
        {
            return dbSet.Add(entity);
        }

        public async Task CreateAsyn(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public EntityEntry<TEntity> Delete(TEntity entity)
        {
            return dbSet.Remove(entity);
        }


        public TEntity FirstOrDefault()
        {
            return this.dbSet.FirstOrDefault();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbSet.FirstOrDefault(predicate);
        }

        public Task<TEntity> FirstOrDefaultAsyn()
        {
            return this.dbSet.FirstOrDefaultAsync();
        }

        public Task<TEntity> FirstOrDefaultAsyn(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbSet.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<TEntity> FromSqlRaw(string sql)
        {
            return this.dbSet.FromSqlRaw(sql);
        }

        public TEntity Get<TKey>(TKey id)
        {
            return (TEntity)this.dbSet.Find(new object[1] { id });
        }

        public IQueryable<TEntity> Get()
        {
            return this.dbSet;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }
        public async Task<TEntity> GetAsyn<TKey>(TKey id)
        {
            return await this.dbSet.FindAsync(new object[1] { id });
        }


        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public IQueryable<TEntity> FromSqlRawByTEntity(String sql, SqlParameter[] parameters)
        {
            return this.dbSet.FromSqlRaw(sql, parameters);
        }

        public EntityEntry<TEntity> Update(TEntity entity)
        {
            return dbSet.Update(entity);
        }

        public List<TEntity> FromSqlRawList(string sql)
        {
            return this.dbSet.FromSqlRaw(sql).ToList();
        }
    }
}