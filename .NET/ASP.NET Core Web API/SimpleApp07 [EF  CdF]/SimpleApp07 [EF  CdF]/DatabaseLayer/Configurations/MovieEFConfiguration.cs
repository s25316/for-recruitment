using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleApp07__EF__CdF_.DatabaseLayer.Configurations
{
    public class MovieEFConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Film");
            builder.HasKey(m => m.IdMovie).HasName("Film_pk");
            builder.Property(m => m.IdMovie).UseIdentityColumn();

            builder.Property(m => m.Name).IsRequired().HasMaxLength(60).HasColumnType("nvarchar");

            Movie[] movies = 
                { 
                new Movie { IdMovie = 1, Name = "GoldenEye", RelizeDate = new DateOnly(1995, 12,1)},
                new Movie { IdMovie = 2, Name = "Jutro nie umiera nigdy ", RelizeDate = new DateOnly(1997,01,16)},
                new Movie { IdMovie = 3, Name = "Świat to za mało", RelizeDate= new DateOnly(1999,11,8)},
            
            };
            builder.HasData(movies);
        }
    }
}
