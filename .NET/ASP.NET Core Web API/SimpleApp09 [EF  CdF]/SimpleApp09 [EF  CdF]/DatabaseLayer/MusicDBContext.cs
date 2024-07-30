using Microsoft.EntityFrameworkCore;
using SimpleApp09__EF__CdF_.DatabaseLayer.Configurations;
using SimpleApp09__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp09__EF__CdF_.DatabaseLayer
{
    public class MusicDBContext : DbContext
    {
        public MusicDBContext(DbContextOptions options) : base(options)
        {
        }

        protected MusicDBContext()
        {
        }

        public virtual DbSet<Musician> Musicians { get; set; }
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Musician>(new MusicianEFConfiguration());
            modelBuilder.ApplyConfiguration<Label>(new LabelEFConfiguration());
            modelBuilder.ApplyConfiguration<Album>(new AlbumEFConfiguration());
            modelBuilder.ApplyConfiguration<Song>(new SongEFCOnfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
