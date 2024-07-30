using SimpleApp08__EF__CdF_.BusinessLogicLayer.Prescription.DTOs;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Prescription.Repositories
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<PrescriptionGetDTO>> GetPrescriptionsAsync();
        Task<bool> PostPrescriptionAsync(PrescriptionPostDTO p);
        Task<bool> DeletePrescriptionAsync(int IdPrescription);
        Task<bool> PostMedicamentsForPrescriptionAsync(int IdPrescription, IEnumerable<PrescriptionMedicamentPostDTO> m);
    }
}
