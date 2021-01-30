using System.Collections.Generic;
using System.Threading.Tasks;
using No.API.Repositories.Interfaces;
using No.API.Services.Interfaces;

namespace No.API.Services
{
    public abstract class BaseService<TRepository, TEntity> : IService<TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : class
    {
        protected TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public virtual Task<List<TEntity>> Get()
        {
            return _repository.Get();
        }

        public virtual Task<int> Store(TEntity entity)
        {
            return _repository.Store(entity);
        }
    }
}