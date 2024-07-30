using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp08__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp08__EF__CdF_.DatabaseLayer.Configurations
{
    public class MedicamentEFConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.ToTable("Medicament");
            builder.HasKey(m => m.IdMedicament).HasName("Medicament_pk");
            builder.Property(m => m.IdMedicament).UseIdentityColumn();

            builder.Property(d => d.Name).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");
            builder.Property(d => d.Type).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");
            builder.Property(d => d.Description).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");

            Medicament[] medicaments = { 
                new Medicament { IdMedicament = 1, Name ="Xanax", Description = "Random ...", Type = "Rand 1" },
                new Medicament { IdMedicament = 2, Name ="Linex", Description = "Random ...", Type = "Rand 2" },
                new Medicament { IdMedicament = 3, Name ="Woda Słona", Description = "Random ...", Type = "Rand 3" },
            };
            builder.HasData(medicaments);
        }
    }
}
