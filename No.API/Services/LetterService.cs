using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using No.API.Entities;
using No.API.Repositories.Interfaces;
using No.API.Services.Interfaces;

namespace No.API.Services
{
    public class LetterService : BaseService<ILetterRepository, Letter>, ILetterService
    {
        private readonly ILogger<LetterService> _logger;

        public LetterService(
            ILetterRepository repository,
            ILogger<LetterService> logger) : base(repository)
        {
            _logger = logger;
        }

        public override async Task<int> Store(Letter entity)
        {
            var letter = await _repository.Get(letter => letter.WritedAt.Date == entity.WritedAt.Date);

            if (letter is not null)
                throw new Exception("Letter already exists");

            return await base.Store(entity);
        }

        public async Task<Letter> Today()
        {
            var now = DateTime.Now;
            var letter = await _repository.Get(letter => letter.WritedAt.Date == now.Date);

            if (letter is null)
                throw new Exception("Letter not write");

            return letter;
        }
    }
}