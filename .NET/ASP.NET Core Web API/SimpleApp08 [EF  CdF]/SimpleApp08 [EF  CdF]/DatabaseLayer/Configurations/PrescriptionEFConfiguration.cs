using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp08__EF__CdF_.DatabaseLayer.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleApp08__EF__CdF_.DatabaseLayer.Configurations
{
    public class PrescriptionEFConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Recepta");
            builder.HasKey(p => p.IdPrescription).HasName("Prescription_pk");
            builder.Property(p => p.IdPrescription).UseIdentityColumn();

            builder.HasOne(p => p.Patient).WithMany(p => p.Prescriptions)
                .HasForeignKey(p => p.IdPatient).HasConstraintName("Prescription_Patient").
                OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Doctor).WithMany(p => p.Prescriptions)
                .HasForeignKey(p => p.IdDoctor).HasConstraintName("Prescription_Doctor")
                .OnDelete(DeleteBehavior.Cascade);

            Prescription[] prescriptions = 
                { 
                new Prescription { IdPrescription = 1, IdDoctor = 1, IdPatient = 1, 
                    Date = DateOnly.FromDateTime(DateTime.Now), DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(10))},
                new Prescription { IdPrescription = 2, IdDoctor = 1, IdPatient = 2,
                    Date = DateOnly.FromDateTime(DateTime.Now), DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(10))},
            }; 
            builder.HasData(prescriptions);
        }
    }
}
