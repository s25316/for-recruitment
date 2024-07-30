using Microsoft.EntityFrameworkCore;
using SimpleApp10__EF__CdF_JWT_.DatabaseLayer.Configurations;
using SimpleApp10__EF__CdF_JWT_.DatabaseLayer.Models;

namespace SimpleApp10__EF__CdF_JWT_.DatabaseLayer
{
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext(DbContextOptions options) : base(options)
        {
        }

        protected LibraryDBContext()
        {
        }
        public virtual DbSet<Person> People { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Person>(new PersonEFConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
