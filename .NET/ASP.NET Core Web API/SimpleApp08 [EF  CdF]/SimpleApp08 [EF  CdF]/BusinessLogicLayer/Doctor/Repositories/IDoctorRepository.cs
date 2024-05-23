using SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.DTOs;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<DoctorGetDTO>> GetDoctorsAsync();
        Task<bool> PostDoctorAsync(DoctorPostDTO d);
        Task<bool> DeleteDoctorAsync(int IdDoctor);
    }
}
