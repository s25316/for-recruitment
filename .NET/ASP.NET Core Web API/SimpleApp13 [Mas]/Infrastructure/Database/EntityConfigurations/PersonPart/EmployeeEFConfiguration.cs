using Application.Database.Models.PersonPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.PersonPart
{
    public class EmployeeEFConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(nameof(Employee));
            builder.HasKey(e => e.Id).HasName($"{nameof(Employee)}_pk");

            builder.HasOne(x => x.Person).WithOne(x => x.Employee)
                .HasForeignKey<Employee>(x => x.Id)
                .HasConstraintName($"{nameof(Employee)}_{nameof(Person)}")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
