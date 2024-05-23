using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp09__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp09__EF__CdF_.DatabaseLayer.Configurations
{
    public class SongEFCOnfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Utwor");
            builder.HasKey(s => s.IdSong).HasName("Utwor_pk");
            builder.Property(s => s.IdSong).UseIdentityColumn()
                .HasColumnName("IdUtwor");

            builder.Property(s => s.SongName).IsRequired().HasMaxLength(30)
                .HasColumnType("nvarchar").HasColumnName("NazwaUtworu");
            builder.Property(s => s.Duration).HasColumnName("CzasTrwania");

            builder.HasOne(s => s.Album).WithMany(s => s.Songs)
                .HasForeignKey(s => s.IdAlbum).HasConstraintName("Songs_Album")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Musicians).WithMany(s => s.Songs)
                .UsingEntity("WykonwcaUtworu", 
                j  => j.HasOne(typeof(Musician)).WithMany().HasForeignKey("IdMuzyk"),
                y => y.HasOne(typeof(Song)).WithMany().HasForeignKey("IdUtwor")
                );

            Song[] data = { 
                new Song{ IdSong = 1, SongName = "Warszawa", Duration = (float)(2.12), IdAlbum = 1 },
                new Song{ IdSong = 2, SongName = "Poznan", Duration = (float)(2.12), IdAlbum = null },
            }; 
            builder.HasData(data);
        }
    }
}
