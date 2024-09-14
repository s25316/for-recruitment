using Application.Database.Models;
using Application.Database.Models.AddressPart;
using Application.Database.Models.PersonPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.AddressPart
{
    internal class AddressEFConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address));
            builder.HasKey(a => a.Id).HasName($"{nameof(Address)}_pk");

            builder.HasOne(x => x.Collocation).WithMany(x => x.Addresses)
                .HasForeignKey(x => new { x.StreetId, x.DivisionId })
                .HasConstraintName($"{nameof(Address)}_{nameof(Collocation)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Depratments).WithOne(x => x.Address)
                .HasForeignKey(x => x.AddressId)
                .HasConstraintName($"{nameof(Address)}_{nameof(Depratment)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.People).WithOne(x => x.Address)
               .HasForeignKey(x => x.AddressId)
               .HasConstraintName($"{nameof(Address)}_{nameof(Person)}")
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
