using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp09__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp09__EF__CdF_.DatabaseLayer.Configurations
{
    public class MusicianEFConfiguration : IEntityTypeConfiguration<Musician>
    {
        public void Configure(EntityTypeBuilder<Musician> builder)
        {
            builder.ToTable("Muzyk");
            builder.HasKey(m => m.IdMusician).HasName("Muzyk_pk");
            builder.Property(m => m.IdMusician).UseIdentityColumn().HasColumnName("IdMuzyk");


            builder.Property(m => m.Name).IsRequired().HasMaxLength(30)
                .HasColumnType("nvarchar").HasColumnName("Imie");
            builder.Property(m => m.Surname).IsRequired().HasMaxLength(40)
                .HasColumnType("nvarchar").HasColumnName("Nazwisko");
            builder.Property(m => m.Nickname).HasMaxLength(50)
                .HasColumnType("nvarchar").HasColumnName("Pseudonim");

            Musician[] data = 
                { 
                new Musician { IdMusician = 1, Name = "Andrzej", Surname = "Kwiatkowski", Nickname = null},
                new Musician { IdMusician = 2, Name = "Damian", Surname = "Cebulski", Nickname = "Cebula"},
                new Musician { IdMusician = 3, Name = "Anna", Surname = "Kwiatkowska", Nickname = null},
            }; 
            builder.HasData(data);
        }
    }
}
