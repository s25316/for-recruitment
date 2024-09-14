using Application.Database.Models.AddressPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.AddressPart
{
    public class AdministrativeTypeEFConfiguration : IEntityTypeConfiguration<AdministrativeType>
    {
        public void Configure(EntityTypeBuilder<AdministrativeType> builder)
        {
            builder.ToTable(nameof(AdministrativeType));
            builder.HasKey(a => a.Id).HasName($"{nameof(AdministrativeType)}_Pk");
            builder.Property(a => a.Id).ValueGeneratedNever();

            builder.HasMany(x => x.Streets).WithOne(x => x.Type)
                .HasForeignKey(x => x.TypeId).HasConstraintName($"{nameof(AdministrativeType)}_{nameof(Street)}")
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.AdministrativeDivisions).WithOne(x => x.Type)
                .HasForeignKey(x => x.TypeId).HasConstraintName($"{nameof(AdministrativeType)}_{nameof(AdministrativeDivision)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
