using Application.Database.Models;
using Application.Database.Models.ContactPart;
using Application.Database.Models.PersonPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.ContactPart
{
    public class HistoryOfContactClientEFConfiguration : IEntityTypeConfiguration<HistoryOfContactClient>
    {
        public void Configure(EntityTypeBuilder<HistoryOfContactClient> builder)
        {
            builder.ToTable(nameof(HistoryOfContactClient));
            builder.HasKey(x => x.Id).HasName($"{nameof(HistoryOfContactClient)}_pk");

            builder.HasOne(x => x.Client).WithMany(x => x.HistoryOfContactClients)
                .HasForeignKey(x => x.ClientId)
                .HasConstraintName($"{nameof(HistoryOfContactClient)}_{nameof(Client)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Depratment).WithMany(x => x.HistoryOfContactClients)
                .HasForeignKey(x => x.DepratmentId)
                .HasConstraintName($"{nameof(HistoryOfContactClient)}_{nameof(Depratment)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
