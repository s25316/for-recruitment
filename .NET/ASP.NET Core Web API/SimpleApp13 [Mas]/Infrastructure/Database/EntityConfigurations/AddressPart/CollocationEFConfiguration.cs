using Application.Database.Models.AddressPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.AddressPart
{
    public class CollocationEFConfiguration : IEntityTypeConfiguration<Collocation>
    {
        public void Configure(EntityTypeBuilder<Collocation> builder)
        {
            builder.ToTable(nameof(Collocation));
            builder.HasKey(x => new { x.StreetId, x.DivisionId }).HasName($"{nameof(Collocation)}_Pk");

            builder.HasOne(x => x.Street).WithMany(x => x.Collocations)
                .HasForeignKey(x => x.StreetId).HasConstraintName($"{nameof(Collocation)}_{nameof(Street)}")
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.AdministrativeDivision).WithMany(x => x.Collocations)
                .HasForeignKey(x => x.DivisionId).HasConstraintName($"{nameof(Collocation)}_{nameof(AdministrativeDivision)}")
                .OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
