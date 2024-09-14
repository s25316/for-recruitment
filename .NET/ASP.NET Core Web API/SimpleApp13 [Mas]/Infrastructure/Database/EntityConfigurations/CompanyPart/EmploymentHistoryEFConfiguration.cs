using Application.Database.Models.CompanyPart;
using Application.Database.Models.PersonPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.CompanyPart
{
    public class EmploymentHistoryEFConfiguration : IEntityTypeConfiguration<EmploymentHistory>
    {
        public void Configure(EntityTypeBuilder<EmploymentHistory> builder)
        {
            builder.ToTable(nameof(EmploymentHistory));
            builder.HasKey(e => e.Id).HasName($"{nameof(EmploymentHistory)}_pk");

            builder.HasOne(x => x.Employee).WithMany(x => x.EmploymentHistories)
                .HasForeignKey(x => x.EmployeeId)
                .HasConstraintName($"{nameof(EmploymentHistory)}_{nameof(Employee)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Company).WithMany(x => x.EmploymentHistories)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName($"{nameof(EmploymentHistory)}_{nameof(Company)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
