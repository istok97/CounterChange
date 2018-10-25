using Microsoft.EntityFrameworkCore;

namespace CounterChangeFile.Models
{
    public class RepositoryDbContext : DbContext
    {
        public  DbSet<Repositories> Repositoryes { get; set;}
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
