using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleApp07__EF__CdF_.DatabaseLayer.Configurations
{
    public class ActorEFConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.ToTable("Aktor");
            builder.HasKey(a => a.IdActor).HasName("Aktor_pk");
            builder.Property(a => a.IdActor).UseIdentityColumn();

            builder.Property(a => a.Name).IsRequired().HasMaxLength(30).HasColumnType("nvarchar");
            builder.Property(a => a.Surname).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
            builder.Property(a => a.Nickname).HasMaxLength(50).HasColumnType("nvarchar");

            Actor[] actors = { 
                new Actor { IdActor = 1, Name = "Frank", Surname = "Castle", Nickname = "Punisher" },
                new Actor { IdActor = 2, Name = "Billy", Surname = "Russo", Nickname = "Jigsaw" },
                new Actor { IdActor = 3, Name = "Caren", Surname = "Page", Nickname = null },
            }; 
            builder.HasData(actors);
        }
    }
}
