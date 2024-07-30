using Microsoft.EntityFrameworkCore;
using SimpleApp08__EF__CdF_.BusinessLogicLayer.Patient.DTOs;
using SimpleApp08__EF__CdF_.DatabaseLayer;
using SimpleApp08__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Patient.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DatabaseContext _context;
        public PatientRepository(DatabaseContext context) { _context = context; }

        public async Task<IEnumerable<PatientGetDTO>> GetPatientsAsync() 
        {
            var list = await _context.Patients.Include(p => p.Prescriptions)
                .ThenInclude(p => p.Doctor).ThenInclude(p => p.Prescriptions)
                .ThenInclude(p => p.PrescriptionMedicaments).ThenInclude(p => p.Medicament)
                .AsNoTracking().Select(p => new PatientGetDTO 
                { 
                    IdPatient = p.IdPatient,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthdate = p.Birthdate,
                    Prescriptions = p.Prescriptions.Select(x => new PatientPrescriptionGetDTO 
                    { 
                        IdPrescription = x.IdPrescription,
                        Date = x.Date,
                        DueDate = x.DueDate,
                        Doctor = new DoctorGetDTO 
                        { 
                            IdDoctor = x.IdDoctor,
                            FirstName = x.Doctor.FirstName,
                            LastName = x.Doctor.LastName,
                            Email = x.Doctor.Email,
                        },
                        Medicamens = x.PrescriptionMedicaments.Select(m => new Doctor.DTOs.PrescriptionMedicamentGetDTO 
                        { 
                            IdMedicament = m.IdMedicament,
                            Dose = m.Dose,
                            Details = m.Details,
                            Name = m.Medicament.Name,
                            Description = m.Medicament.Description,
                            Type = m.Medicament.Type,
                        }).ToList(),
                    }).ToList(),
                }).ToListAsync();
            return list;
        }

        public async Task<bool> PostPatientAsync(PatientPostDTO p) 
        {
            await _context.Patients.AddAsync(new DatabaseLayer.Models.Patient 
            { 
                FirstName = p.FirstName,
                LastName = p.LastName,
                Birthdate = new DateOnly(p.Year, p.Month, p.Day),
            });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePatientAsync(int IdPatient) 
        {
            var p = await _context.Patients.FindAsync(IdPatient);
            if (p == null) { return false; }
            _context.Patients.Remove(p);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
