using Microsoft.EntityFrameworkCore;
using SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.DTOs;
using SimpleApp08__EF__CdF_.BusinessLogicLayer.Prescription.DTOs;
using SimpleApp08__EF__CdF_.DatabaseLayer;
using SimpleApp08__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Prescription.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly DatabaseContext _context;
        public PrescriptionRepository(DatabaseContext context) { _context = context; }

        public async Task<IEnumerable<PrescriptionGetDTO>> GetPrescriptionsAsync() 
        {
            var list = await _context.Prescriptions.Include(p => p.Doctor).Include(p => p.Patient)
                .Include(p => p.PrescriptionMedicaments).ThenInclude(p => p.Medicament)
                .AsNoTracking().Select(p => new PrescriptionGetDTO 
                { 
                    IdPrescription = p.IdPrescription,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Doctor = new Doctor.DTOs.DoctorGetDTO 
                    { 
                        IdDoctor = p.IdDoctor,
                        FirstName = p.Doctor.FirstName,
                        LastName = p.Doctor.LastName,
                        Email = p.Doctor.Email,
                    },
                    Patient = new Doctor.DTOs.PatientGetDTO 
                    { 
                        IdPatient = p.IdPatient,
                        FirstName= p.Patient.FirstName,
                        LastName= p.Patient.LastName,
                        Birthdate = p.Patient.Birthdate,
                    },
                    Medicaments = p.PrescriptionMedicaments.Select(x => new PrescriptionMedicamentGetDTO 
                    { 
                        IdMedicament = x.IdMedicament,
                        Dose = x.Dose,
                        Details = x.Details,
                        Description = x.Medicament.Description,
                        Name = x.Medicament.Name,
                        Type = x.Medicament.Type,
                    } ).ToList(),
                }).ToListAsync();
            return list;
        }

        public async Task<bool> PostPrescriptionAsync(PrescriptionPostDTO p) 
        {
            await _context.Prescriptions.AddAsync(new DatabaseLayer.Models.Prescription 
            { 
                Date = DateOnly.FromDateTime(DateTime.Now),
                DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(p.ValidityTermDays)),
                IdDoctor = p.IdDoctor,
                IdPatient = p.IdPatient,
            });
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeletePrescriptionAsync(int IdPrescription) 
        {
            var p = await _context.Prescriptions.FindAsync(IdPrescription);
            if (p == null) { return false; }
            _context.Prescriptions.Remove(p);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PostMedicamentsForPrescriptionAsync(int IdPrescription, IEnumerable<PrescriptionMedicamentPostDTO> m) 
        { 
            var tran = await _context.Database.BeginTransactionAsync();
            try 
            {             
                foreach (var p in m) 
                {
                    if (p == null) continue;
                    await _context.PrescriptionMedicaments.AddAsync( new PrescriptionMedicament 
                    { 
                        IdMedicament = p.IdMedicament,
                        IdPrescription = IdPrescription,
                        Details = p.Details,
                        Dose = p.Dose,
                    });
                }
                await _context.SaveChangesAsync();
            } catch (Exception ex) 
            { 
                await tran.RollbackAsync();  
                return false;
            }            
            await tran.CommitAsync();
            return true;
        }
    }
}
