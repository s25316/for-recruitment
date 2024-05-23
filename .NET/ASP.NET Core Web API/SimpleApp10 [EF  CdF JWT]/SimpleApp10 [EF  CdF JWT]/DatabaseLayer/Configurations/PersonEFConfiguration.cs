using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp10__EF__CdF_JWT_.DatabaseLayer.Models;

namespace SimpleApp10__EF__CdF_JWT_.DatabaseLayer.Configurations
{
    public class PersonEFConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(p => p.IdPearson).HasName("Person_pk");

            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Salt).IsRequired().HasMaxLength(50);
            
            builder.Property(p => p.JWT).HasMaxLength(int.MaxValue);
            builder.Property(p => p.RefreshToken).HasMaxLength(int.MaxValue);

            builder.HasAlternateKey(p => p.Email).HasName("Person_email");
        }
    }
}
