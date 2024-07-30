using Microsoft.EntityFrameworkCore;
using SimpleApp06__EF__CdF_.DatabaseLayer.Configurations;

namespace SimpleApp06__EF__CdF_.DatabaseLayer
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<CarPerson> CarPeople { get; set; } 

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\localServer;Initial Catalog=APBD1;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Car>(new CarEFConfiguration());
            modelBuilder.ApplyConfiguration<Person> (new  PersonEFConfiguration());
            modelBuilder.ApplyConfiguration<CarPerson> (new CarPersonEFConfiguration());
        }
    }
}
