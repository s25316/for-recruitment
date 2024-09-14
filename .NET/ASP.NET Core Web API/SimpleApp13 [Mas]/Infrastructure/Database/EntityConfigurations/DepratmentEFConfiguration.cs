using Application.Database.Models;
using Application.Database.Models.PersonPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations
{
    internal class DepratmentEFConfiguration : IEntityTypeConfiguration<Depratment>
    {
        public void Configure(EntityTypeBuilder<Depratment> builder)
        {
            builder.ToTable(nameof(Depratment));
            builder.HasKey(x => x.Id).HasName($"{nameof(Depratment)}_pk");

            builder.HasMany(x => x.Employees).WithMany(x => x.EmployeeDepratments)
                .UsingEntity("EmployeeDepratment",

                j => j.HasOne(typeof(Employee)).WithMany()
                .HasForeignKey($"Id{typeof(Employee)}").OnDelete(DeleteBehavior.Restrict),

                i => i.HasOne(typeof(Depratment)).WithMany()
                .HasForeignKey($"Id{typeof(Depratment)}").OnDelete(DeleteBehavior.Restrict)
                );

            builder.HasMany(x => x.Managers).WithMany(x => x.ManagerDepratments)
               .UsingEntity("ManagerDepratment",

               j => j.HasOne(typeof(Employee)).WithMany()
               .HasForeignKey($"Id{typeof(Employee)}").OnDelete(DeleteBehavior.Restrict),

               i => i.HasOne(typeof(Depratment)).WithMany()
               .HasForeignKey($"Id{typeof(Depratment)}").OnDelete(DeleteBehavior.Restrict)
               );
        }
    }
}
