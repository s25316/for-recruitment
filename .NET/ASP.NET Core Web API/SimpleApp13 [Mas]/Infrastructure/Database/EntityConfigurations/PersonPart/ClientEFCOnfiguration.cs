using Application.Database.Models.PersonPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.PersonPart
{
    public class ClientEFCOnfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(nameof(Client));
            builder.HasKey(x => x.Id).HasName($"{nameof(Client)}_pk");

            builder.HasOne(x => x.Person).WithOne(x => x.Client)
                .HasForeignKey<Client>(x => x.Id)
                .HasConstraintName($"{nameof(Client)}_{nameof(Person)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Employee).WithMany(x => x.Clients)
                .HasForeignKey(x => x.EmploeeId)
                .HasConstraintName($"{nameof(Client)}_{nameof(Employee)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
