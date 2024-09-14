using Application.Database.Models.CompanyPart;
using Application.Database.Models.UniversityPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.UniversityPart
{
    public class UniversityEFConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.ToTable(nameof(University));
            builder.HasKey(x => x.Id).HasName($"{nameof(University)}_pk");

            builder.HasOne(x => x.Company).WithOne(x => x.University)
                .HasForeignKey<University>(x => x.Id)
                .HasConstraintName($"{nameof(University)}_{nameof(Company)}")
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
