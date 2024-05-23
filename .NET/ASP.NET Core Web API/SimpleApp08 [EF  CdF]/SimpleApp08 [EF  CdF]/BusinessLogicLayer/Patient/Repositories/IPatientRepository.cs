using SimpleApp08__EF__CdF_.BusinessLogicLayer.Patient.DTOs;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Patient.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<PatientGetDTO>> GetPatientsAsync();
        Task<bool> PostPatientAsync(PatientPostDTO p);
        Task<bool> DeletePatientAsync(int IdPatient);
    }
}
