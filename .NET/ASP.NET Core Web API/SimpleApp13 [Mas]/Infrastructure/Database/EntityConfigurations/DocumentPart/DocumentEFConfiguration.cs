using Application.Database.Models.DocumentPart;
using Application.Database.Models.PersonPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.DocumentPart
{
    public class DocumentEFConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable(nameof(Document));
            builder.HasKey(e => e.Id).HasName($"{nameof(Document)}_pk");

            builder.HasOne(x => x.DocumentType).WithMany(x => x.Documents)
                .HasForeignKey(x => x.DocumentTypeId)
                .HasConstraintName($"{nameof(Document)}_{nameof(DocumentType)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Person).WithMany(x => x.Documents)
                .HasForeignKey(x => x.PersonId)
                .HasConstraintName($"{nameof(Document)}_{nameof(Person)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
