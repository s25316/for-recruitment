using Application.Database.Models;
using Application.Database.Models.CompanyPart;
using Application.Database.Models.ContactPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.ContactPart
{
    public class HistoryOfContactCompanyEFConfiguration : IEntityTypeConfiguration<HistoryOfContactCompany>
    {
        public void Configure(EntityTypeBuilder<HistoryOfContactCompany> builder)
        {
            builder.ToTable(nameof(HistoryOfContactCompany));
            builder.HasKey(x => x.Id).HasName($"{nameof(HistoryOfContactCompany)}_pk");

            builder.HasOne(x => x.Company).WithMany(x => x.HistoryOfContactCompanies)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName($"{nameof(HistoryOfContactCompany)}_{nameof(Company)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Depratment).WithMany(x => x.HistoryOfContactCompanies)
                .HasForeignKey(x => x.DepratmentId)
                .HasConstraintName($"{nameof(HistoryOfContactCompany)}_{nameof(Depratment)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
