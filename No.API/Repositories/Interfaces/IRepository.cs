using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace No.API.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> Get();
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<int> Store(T entity);
    }
}