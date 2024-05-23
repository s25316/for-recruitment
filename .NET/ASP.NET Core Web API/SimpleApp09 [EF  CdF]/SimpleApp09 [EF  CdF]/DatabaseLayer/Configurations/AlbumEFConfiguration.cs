using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp09__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp09__EF__CdF_.DatabaseLayer.Configurations
{
    public class AlbumEFConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");
            builder.HasKey(a => a.IdAlbum).HasName("Album_pk");
            builder.Property(a => a.IdAlbum).UseIdentityColumn()
                .HasColumnName("IdAlbum");

            builder.Property(a => a.NameAlbum).IsRequired().HasMaxLength(30)
                .HasColumnType("nvarchar").HasColumnName("NazwaAlbumu");
            builder.Property(a => a.ReleaseDate).IsRequired()
                .HasColumnName("DataWydania");

            builder.HasOne(a => a.Label).WithMany(a => a.Albums)
                .HasForeignKey(a => a.IdLabel).HasConstraintName("Albums_Label")
                .OnDelete(DeleteBehavior.Restrict);

            Album[] data = { 
                new Album {IdAlbum = 1, NameAlbum = "Syrenki", ReleaseDate = DateTime.Now, IdLabel = 1 },
                new Album {IdAlbum = 2, NameAlbum = "Nadwislanskie Szanty", ReleaseDate = DateTime.Now, IdLabel = 1 },
            }; 
            builder.HasData(data);
        }
    }
}
