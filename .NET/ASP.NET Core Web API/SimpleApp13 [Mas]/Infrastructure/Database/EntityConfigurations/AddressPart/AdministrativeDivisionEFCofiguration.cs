using Application.Database.Models.AddressPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.AddressPart
{
    public class AdministrativeDivisionEFCofiguration : IEntityTypeConfiguration<AdministrativeDivision>
    {
        public void Configure(EntityTypeBuilder<AdministrativeDivision> builder)
        {
            builder.ToTable(nameof(AdministrativeDivision));
            builder.HasKey(x => x.Id).HasName($"{nameof(AdministrativeDivision)}_Pk");
            builder.Property(x => x.Id).ValueGeneratedNever();

        }
    }
}
