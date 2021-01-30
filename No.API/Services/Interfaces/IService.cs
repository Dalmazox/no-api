using System.Collections.Generic;
using System.Threading.Tasks;

namespace No.API.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<List<T>> Get();
        Task<int> Store(T entity);
    }
}