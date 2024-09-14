using Application.Database.Models.PersonPart;
using Application.Database.Models.UniversityPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.UniversityPart
{
    public class EducationHistoryEFConfiguration : IEntityTypeConfiguration<EducationHistory>
    {
        public void Configure(EntityTypeBuilder<EducationHistory> builder)
        {
            builder.ToTable(nameof(EducationHistory));
            builder.HasKey(x => x.Id).HasName($"{nameof(EducationHistory)}_pk");

            builder.HasOne(x => x.University).WithMany(x => x.EducationHistories)
                .HasForeignKey(x => x.UniversityId)
                .HasConstraintName($"{nameof(EducationHistory)}_{nameof(University)}")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Employee).WithMany(x => x.EducationHistories)
                .HasForeignKey(x => x.EmployeeId)
                .HasConstraintName($"{nameof(EducationHistory)}_{nameof(Employee)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
