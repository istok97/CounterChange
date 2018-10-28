using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CounterChangeFile.Models
{
    public class RepositoryDbContext : DbContext
    {
        public  DbSet<Files> Files { get; set;}

        public DbSet<Repos> Repos { get; set; }

        public DbSet< Analysis> Analysis { get; set; }

        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

       
    }
}
