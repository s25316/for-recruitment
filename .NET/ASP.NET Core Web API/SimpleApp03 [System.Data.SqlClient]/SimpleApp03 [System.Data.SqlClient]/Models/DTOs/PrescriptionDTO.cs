using System.ComponentModel.DataAnnotations;

namespace SimpleApp03__System.Data.SqlClient_.Models.DTOs
{
    public class PrescriptionDTO
    {
        public required int IdPrescription { get; set; }
        public required DateOnly Date { get; set; }
        public required DateOnly DueDate { get; set; }
        [StringLength(100)]
        public required string DoctorName { get; set; }
        [StringLength(100)]
        public required string DoctorLastName { get; set; }
        [StringLength(100)]
        public required string DoctorEmail { get; set; }
        [StringLength(100)]
        public required string PatientName { get; set; }
        [StringLength(100)]
        public required string PatientLastName { get; set; }
        [StringLength(100)]
        public required DateOnly PatientBirthdate { get; set; }
        public IEnumerable<PrescriptionDetailsDTO> Details { get; set; } = new List<PrescriptionDetailsDTO>();
    }
}
