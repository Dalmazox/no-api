using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using No.API.Context;
using No.API.Repositories.Interfaces;

namespace No.API.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly NoContext _context;
        protected readonly DbSet<T> _dbSet;

        protected BaseRepository(NoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual Task<List<T>> Get()
        {
            return _dbSet.ToListAsync<T>();
        }

        public Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefaultAsync(filter);
        }

        public virtual Task<int> Store(T entity)
        {
            _dbSet.AddAsync(entity);
            return _context.SaveChangesAsync();
        }
    }
}