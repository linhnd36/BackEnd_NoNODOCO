using Data_Tier.GenericRepository;
using Data_Tier.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVoucher.BaseService
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
       where TEntity : class
    {
        protected IUnitOfWork _unitOfWork;
        protected IGenericRepository<TEntity> _repository;

        public BaseService()
        {
        }

        public BaseService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        protected BaseService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _repository.AddRange(entities);
            _unitOfWork.Commit();
        }

        public async Task AddRangeAsyn(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsyn(entities);
            await SaveAsyn();
        }

        public int Count()
        {
            return _repository.Count();
        }

        public TEntity Create(TEntity entity)
        {
            TEntity result = _repository.Create(entity).Entity;
            Save();
            return result;

        }

        public async Task CreateAsyn(TEntity entity)
        {
            await _repository.CreateAsyn(entity);
            await SaveAsyn();
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            Save();
        }

        public async Task DeleteAsyn(TEntity entity)
        {
            _repository.Delete(entity);
            await SaveAsyn();
        }

        public TEntity FirstOrDefault()
        {
            return _repository.FirstOrDefault();
        }

        public TEntity FirstOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.FirstOrDefault(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsyn()
        {
            return await _repository.FirstOrDefaultAsyn();
        }

        public async Task<TEntity> FirstOrDefaultAsyn(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.FirstOrDefaultAsyn(predicate);
        }

        public TEntity Get<TKey>(TKey id)
        {
            return _repository.Get(id);
        }

        public System.Linq.IQueryable<TEntity> Get()
        {
            return _repository.Get();
        }

        public IQueryable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Get(predicate);
        }

        public async Task<TEntity> GetAsyn<TKey>(TKey id)
        {
            return await _repository.GetAsyn(id);
        }

        public TEntity GetAvaiableObjectById(int Id)
        {
            String sql = "Select * from dbo." + typeof(TEntity).Name + " where Id = " + Id;
            return (TEntity)_repository.FromSqlRaw(sql);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            Save();
        }

        public async Task RemoveRangeAsyn(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            await SaveAsyn();
        }

        public Boolean Save()
        {
            return _unitOfWork.Commit();
        }

        public async Task SaveAsyn()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsyn(TEntity entity)
        {
            _repository.Update(entity);
            await SaveAsyn();
        }

        public TEntity DeleteOne(int id)
        {
            TEntity entity = Get(id);
            TEntity result = _repository.Delete(entity).Entity;
            if (!Save())
            {
                return null;
            }
            return result;
        }

        public TEntity Update(TEntity entity)
        {
            TEntity result = _repository.Update(entity).Entity;
            if (!Save())
            {
                return null;
            }
            return result;
        }

    }

}

