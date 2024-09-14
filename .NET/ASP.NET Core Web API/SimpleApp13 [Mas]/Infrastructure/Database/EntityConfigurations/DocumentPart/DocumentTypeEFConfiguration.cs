using Application.Database.Models.DocumentPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.DocumentPart
{
    public class DocumentTypeEFConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable(nameof(DocumentType));
            builder.HasKey(x => x.Id).HasName($"{nameof(DocumentType)}_pk");
            builder.Property(x => x.Id).ValueGeneratedNever();

            DocumentType[] data =
            {
            new DocumentType { Id = 1, Name = "Dowod Osobisty" },
            new DocumentType { Id = 2, Name = "Paszport" },
            new DocumentType { Id = 3, Name = "Karta Pobytu" },
            };
            builder.HasData(data);
        }
    }
}
