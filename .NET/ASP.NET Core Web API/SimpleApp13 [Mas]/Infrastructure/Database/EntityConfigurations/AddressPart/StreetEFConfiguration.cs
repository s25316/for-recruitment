using Application.Database.Models.AddressPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.AddressPart
{
    internal class StreetEFConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
        {
            builder.ToTable(nameof(Street));
            builder.HasKey(x => x.Id).HasName($"{nameof(Street)}_Pk");
            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
