using Application.Database.Models.AddressPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.AddressPart
{
    public class CountryEFConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(nameof(Country));
            builder.HasKey(x => x.Id).HasName($"{nameof(Country)}_Pk");
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasMany(x => x.AdministrativeDivisions).WithOne(x => x.Country)
                .HasForeignKey(x => x.CountryId).HasConstraintName($"{nameof(Country)}_{nameof(AdministrativeDivision)}")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
