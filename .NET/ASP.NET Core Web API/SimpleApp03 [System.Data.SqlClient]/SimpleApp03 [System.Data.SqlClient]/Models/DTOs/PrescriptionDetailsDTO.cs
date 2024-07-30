using System.ComponentModel.DataAnnotations;

namespace SimpleApp03__System.Data.SqlClient_.Models.DTOs
{
    public class PrescriptionDetailsDTO
    {
        public required int Dose { get; set; }
        [StringLength(100)]
        public required string Details { get; set; }
        [StringLength(100)]
        public required string Name { get; set; }
        [StringLength(100)]
        public required string Description { get; set; }
        public required string Type { get; set; }
    }
}
