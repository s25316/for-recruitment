using SimpleApp03__System.Data.SqlClient_.Models;
using SimpleApp03__System.Data.SqlClient_.Models.DTOs;

namespace SimpleApp03__System.Data.SqlClient_.Entities
{
    public interface IPrescriptionsRepository
    {
        Task<IEnumerable<PrescriptionDTO>> GetPrescriptionsAsync(string? PatientName = null);
        Task<Request> AddMedicineToPrescriptionTransactionAsync(int IdPrescription, List<PostMedicinePrescription> pm);        
     }
}
