using System.ComponentModel.DataAnnotations;

namespace SimpleApp04__System.Data.SqlClient_.Models.DTOs
{
    public class Player_TeamDTO
    {
        public required int NumOnShirt { get; set; }
        [StringLength(300)]
        public string? Comment { get; set; } = null;
    }
}
