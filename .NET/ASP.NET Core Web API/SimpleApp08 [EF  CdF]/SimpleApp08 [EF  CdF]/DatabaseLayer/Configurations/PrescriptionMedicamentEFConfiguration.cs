using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp08__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp08__EF__CdF_.DatabaseLayer.Configurations
{
    public class PrescriptionMedicamentEFConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.ToTable("PrescriptionMedicament");
            builder.HasKey(x => new {x.IdMedicament,x.IdPrescription}).HasName("PrescriptionMedicament_pk");

            builder.Property(x => x.Details).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");

            builder.HasOne(x => x.Prescription).WithMany(x => x.PrescriptionMedicaments)
                .HasForeignKey(x => x.IdPrescription).HasConstraintName("PrescriptionMedicaments_Prescription")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Medicament).WithMany(x => x.PrescriptionMedicaments)
                .HasForeignKey(x => x.IdMedicament).HasConstraintName("PrescriptionMedicaments_Medicament")
                .OnDelete(DeleteBehavior.Cascade);

            PrescriptionMedicament[] data = { 
                new PrescriptionMedicament{ IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "Raz na dzień"},
                new PrescriptionMedicament{ IdMedicament = 2, IdPrescription = 1, Dose = 3, Details = "Trzy razy na dzień"},
                new PrescriptionMedicament{ IdMedicament = 3, IdPrescription = 1, Dose = null, Details = "Dowolne stosowanie"},
            };  
            builder.HasData(data);
        }
    }
}
