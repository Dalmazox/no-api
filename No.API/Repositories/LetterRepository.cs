using No.API.Context;
using No.API.Entities;
using No.API.Repositories.Interfaces;

namespace No.API.Repositories
{
    public class LetterRepository : BaseRepository<Letter>, ILetterRepository
    {
        public LetterRepository(NoContext context) : base(context)
        {
        }
    }
}