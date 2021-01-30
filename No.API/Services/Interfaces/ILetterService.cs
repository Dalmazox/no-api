using System.Threading.Tasks;
using No.API.Entities;

namespace No.API.Services.Interfaces
{
    public interface ILetterService : IService<Letter>
    {
        Task<Letter> Today();
    }
}