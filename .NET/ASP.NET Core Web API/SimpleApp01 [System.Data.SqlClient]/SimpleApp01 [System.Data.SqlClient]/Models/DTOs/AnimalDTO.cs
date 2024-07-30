using System.ComponentModel.DataAnnotations;

namespace SimpleApp01__System.Data.SqlClient_.Models.DTOs
{
    public class AnimalDTO
    {
        [StringLength(200, ErrorMessage = "Przekaracza 200 znaków")]
        public required string Name { get; set; }
        [StringLength(200, ErrorMessage = "Przekaracza 200 znaków")]
        public string? Description { get; set; } = null;
        [StringLength(200, ErrorMessage = "Przekaracza 200 znaków")]
        public required string Category { get; set; }
        [StringLength(200, ErrorMessage = "Przekaracza 200 znaków")]
        public required string Area { get; set; }
    }
}
