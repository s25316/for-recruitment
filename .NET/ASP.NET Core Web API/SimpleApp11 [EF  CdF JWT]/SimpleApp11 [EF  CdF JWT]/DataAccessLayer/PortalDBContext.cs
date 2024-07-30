using Microsoft.EntityFrameworkCore;
using SimpleApp11__EF__CdF_JWT_.DataAccessLayer.Configurations;
using SimpleApp11__EF__CdF_JWT_.DataAccessLayer.Models;

namespace SimpleApp11__EF__CdF_JWT_.DataAccessLayer
{
    public class PortalDBContext : DbContext
    {
        public PortalDBContext(DbContextOptions options) : base(options)
        {
        }

        protected PortalDBContext()
        {
        }

        public virtual DbSet<UserEFModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<UserEFModel>(new UserEFConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
