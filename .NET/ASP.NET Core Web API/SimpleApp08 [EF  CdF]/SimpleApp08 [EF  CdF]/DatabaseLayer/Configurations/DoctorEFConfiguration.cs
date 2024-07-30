using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp08__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp08__EF__CdF_.DatabaseLayer.Configurations
{
    public class DoctorEFConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doktor");
            builder.HasKey(d => d.IdDoctor).HasName("Doktor_pk");
            builder.Property(d => d.IdDoctor).UseIdentityColumn();

            builder.Property(d => d.FirstName).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");
            builder.Property(d => d.LastName).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");
            builder.Property(d => d.Email).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");

            Doctor[] doctors = {
                new Doctor { IdDoctor = 1, FirstName ="Krzysztof", LastName = "Nowak", Email ="kn@wp.pl" },
                new Doctor { IdDoctor = 2, FirstName ="Waldemar", LastName = "Cegliński", Email ="wc@wp.pl" },
                new Doctor { IdDoctor = 3, FirstName ="Aadrzej", LastName = "Chlebowski", Email ="kn@wp.pl" },
            };
            builder.HasData(doctors);
        }
    }
}
