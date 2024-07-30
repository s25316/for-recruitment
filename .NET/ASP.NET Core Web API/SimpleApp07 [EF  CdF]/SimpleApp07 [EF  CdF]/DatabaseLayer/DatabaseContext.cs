using Microsoft.EntityFrameworkCore;
using SimpleApp07__EF__CdF_.DatabaseLayer.Configurations;

namespace SimpleApp07__EF__CdF_.DatabaseLayer
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<ActorMovie> ActorMovies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Movie>(new MovieEFConfiguration());
            modelBuilder.ApplyConfiguration<Actor>(new ActorEFConfiguration());
            modelBuilder.ApplyConfiguration<ActorMovie>(new ActorMovieEFCOnfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
