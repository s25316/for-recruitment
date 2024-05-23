using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp08__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp08__EF__CdF_.DatabaseLayer.Configurations
{
    public class PatientEFConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Pacjent");
            builder.HasKey(p => p.IdPatient).HasName("Patient_pk");
            builder.Property(p => p.IdPatient).UseIdentityColumn();

            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");

            Patient[] patients = { 
                new Patient{ IdPatient = 1, FirstName ="Dariusz", LastName = "Chuchrowski", Birthdate = new DateOnly(1970,1,12) },
                new Patient{ IdPatient = 2, FirstName ="Damian", LastName = "Bystroń", Birthdate = new DateOnly(1980,5,17) },
                new Patient{ IdPatient = 3, FirstName ="Anna", LastName = "Bryłka", Birthdate = new DateOnly(1992,9,22) },
            };
            builder.HasData(patients);
        }
    }
}
