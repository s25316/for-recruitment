using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleApp07__EF__CdF_.DatabaseLayer.Configurations
{
    public class ActorMovieEFCOnfiguration : IEntityTypeConfiguration<ActorMovie>
    {
        public void Configure(EntityTypeBuilder<ActorMovie> builder)
        {
            builder.ToTable("AktorFilm");
            builder.HasKey(a => a.IdActorMovie).HasName("AktorFilm_pk");

            builder.Property(a => a.CharacterName).IsRequired().HasMaxLength(70).HasColumnType("nvarchar");

            builder.HasOne(a => a.Movie).WithMany(a => a.ActorMovies)
                .HasForeignKey(a => a.IdMovie).HasConstraintName("ActorMovie_Movie")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Actor).WithMany(a => a.ActorMovies)
                .HasForeignKey(a => a.IdActor).HasConstraintName("ActorMovie_Actor")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
