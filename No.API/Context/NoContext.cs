using Microsoft.EntityFrameworkCore;
using No.API.Context.Map;

namespace No.API.Context
{
    public class NoContext : DbContext
    {
        public NoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LetterMap).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}