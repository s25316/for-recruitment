using Application.Database.Models.ContactPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.ContactPart
{
    internal class HistoryOfContactEFConfiguration : IEntityTypeConfiguration<HistoryOfContact>
    {
        public void Configure(EntityTypeBuilder<HistoryOfContact> builder)
        {
            builder.ToTable(nameof(HistoryOfContact));
            builder.HasKey(x => x.Id).HasName($"{nameof(HistoryOfContact)}_pk");

            //1-*
            builder.HasOne(x => x.Status).WithMany(x => x.HistoryOfContacts)
                .HasForeignKey(x => x.IdStatus)
                .HasConstraintName($"{nameof(HistoryOfContact)}_{nameof(ContactStatus)}")
                .OnDelete(DeleteBehavior.Restrict);
            //1-1
            builder.HasOne(x => x.HistoryOfContactClient).WithOne(x => x.Contact)
                .HasForeignKey<HistoryOfContactClient>(x => x.Id)
                .HasConstraintName($"{nameof(HistoryOfContact)}_{nameof(HistoryOfContactClient)}")
                .OnDelete(DeleteBehavior.Restrict);
            //1-1
            builder.HasOne(x => x.HistoryOfContactCompany).WithOne(x => x.Contact)
                .HasForeignKey<HistoryOfContactCompany>(x => x.Id)
                .HasConstraintName($"{nameof(HistoryOfContact)}_{nameof(HistoryOfContactCompany)}")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
