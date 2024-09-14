using Application.Database.Models.ContactPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.ContactPart
{
    public class ContactStatusEFConfiguration : IEntityTypeConfiguration<ContactStatus>
    {
        public void Configure(EntityTypeBuilder<ContactStatus> builder)
        {
            builder.ToTable(nameof(ContactStatus));
            builder.HasKey(x => x.Id).HasName($"{nameof(ContactStatus)}_pk");
            builder.Property(x => x.Id).ValueGeneratedNever();

            ContactStatus[] data =
                {
                new ContactStatus { Id = 1, Name = "Utworzone" },
                new ContactStatus { Id = 2, Name = "WyslaneNieOdczytane" },
                new ContactStatus { Id = 3, Name = "Anulowane" },
                new ContactStatus { Id = 4, Name = "Odzczytane" },
                new ContactStatus { Id = 5, Name = "OdzczytaneZaakceptowane" },
                new ContactStatus { Id = 6, Name = "OdzczytaneNieZaakaceptowane" },
                new ContactStatus { Id = 7, Name = "ZwroconeZaakceptowane" },
                new ContactStatus { Id = 8, Name = "ZwroconeNieZaakaceptowane" },
                new ContactStatus { Id = 9, Name = "Zakonczone" },
            };
            builder.HasData(data);
        }
    }
}
