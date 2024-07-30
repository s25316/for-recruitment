using Microsoft.EntityFrameworkCore;
using SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.DTOs;
using SimpleApp08__EF__CdF_.DatabaseLayer;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DatabaseContext _dbContext;
        public DoctorRepository(DatabaseContext dbContext) { _dbContext = dbContext; }

        public async Task<IEnumerable<DoctorGetDTO>> GetDoctorsAsync() 
        {
           var list = await _dbContext.Doctors.Include(p => p.Prescriptions)
                .ThenInclude(p => p.Patient).ThenInclude(p => p.Prescriptions)
                .ThenInclude(p => p.PrescriptionMedicaments).ThenInclude(p => p.Medicament)
                .AsNoTracking().Select(p => new DoctorGetDTO 
                { 
                    IdDoctor = p.IdDoctor,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Email = p.Email,
                    Prescriptions = p.Prescriptions.Select( x => new DoctorPrescriptionGetDTO 
                    { 
                        IdPrescription = x.IdPrescription,
                        Date = x.Date,
                        DueDate = x.DueDate,
                        Patient = new PatientGetDTO 
                        { 
                            IdPatient = x.IdPatient,
                            FirstName = x.Patient.FirstName,
                            LastName = x.Patient.LastName,
                            Birthdate = x.Patient.Birthdate,
                        },
                        Medicaments = x.PrescriptionMedicaments.Select(z => new PrescriptionMedicamentGetDTO 
                        { 
                            IdMedicament = z.IdMedicament,
                            Dose = z.Dose,
                            Details = z.Details,
                            Name = z.Medicament.Name,
                            Description = z.Medicament.Description,
                            Type = z.Medicament.Type,
                        }).ToList(),
                    }).ToList(),
                }).ToListAsync();
            return list;
        }

        public async Task<bool> PostDoctorAsync(DoctorPostDTO d) 
        {
            await _dbContext.Doctors.AddAsync(new DatabaseLayer.Models.Doctor 
            { 
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email,
            });
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDoctorAsync(int IdDoctor) 
        {
            var d = await _dbContext.Doctors.FindAsync(IdDoctor);
            if (d != null) 
            { 
                _dbContext.Doctors.Remove(d); 
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
