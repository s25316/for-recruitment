using MAS05.DatabaseLayer.Configurations;
using MAS05.DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MAS05.DatabaseLayer
{
    internal class BeeDBContext : DbContext
    {
        public BeeDBContext(DbContextOptions options) : base(options)
        {
        }

        public BeeDBContext()
        {
        }
        public virtual DbSet<Bee> Bees { get; set; }
        public virtual DbSet<BeeHome> BeeHomes { get; set; }
        public virtual DbSet<BeeHomeAndBee> BeeHomeAndBee { get; set; }
        public virtual DbSet<BeeSecurity> BeeSecurities { get; set; }
        public virtual DbSet<BeeIntelligence> BeeIntelligences { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder configuration = new ConfigurationBuilder();
            IConfiguration conf = configuration.AddUserSecrets<Program>().Build();
            string connectionString = conf.GetSection("ConnectionStrings")["DBString"] ?? 
                throw new Exception("Connection string not configured");
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Bee>(new BeeEFConfiguration());
            modelBuilder.ApplyConfiguration<BeeHome> (new BeeHomeEFConfiguration());
            modelBuilder.ApplyConfiguration<BeeHomeAndBee>(new BeeHomeAndBeeConfiguration());
            modelBuilder.ApplyConfiguration<BeeIntelligence>(new BeeIntelligenceEFConfiguration());
            modelBuilder.ApplyConfiguration<BeeSecurity>(new BeeSecurityEFConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
