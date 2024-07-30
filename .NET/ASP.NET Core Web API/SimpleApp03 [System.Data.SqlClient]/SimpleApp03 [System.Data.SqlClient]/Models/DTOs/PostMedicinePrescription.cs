using System.ComponentModel.DataAnnotations;

namespace SimpleApp03__System.Data.SqlClient_.Models.DTOs
{
    public class PostMedicinePrescription
    {
        [StringLength(100)]
        public required string Name { get; set; }
        public required int Dose { get; set; }
        [StringLength(100)]
        public required string Details { get; set; }    
    }
}
