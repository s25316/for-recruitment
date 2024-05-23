using Microsoft.EntityFrameworkCore;
using SimpleApp08__EF__CdF_.DatabaseLayer.Configurations;
using SimpleApp08__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp08__EF__CdF_.DatabaseLayer
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Doctor>(new DoctorEFConfiguration());
            modelBuilder.ApplyConfiguration<Patient>(new PatientEFConfiguration());
            modelBuilder.ApplyConfiguration<Prescription>(new PrescriptionEFConfiguration());
            modelBuilder.ApplyConfiguration<Medicament>(new MedicamentEFConfiguration());
            modelBuilder.ApplyConfiguration<PrescriptionMedicament>(new PrescriptionMedicamentEFConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
