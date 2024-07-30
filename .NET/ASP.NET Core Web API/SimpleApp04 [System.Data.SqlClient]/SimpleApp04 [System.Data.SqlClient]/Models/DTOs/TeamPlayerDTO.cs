using System.ComponentModel.DataAnnotations;

namespace SimpleApp04__System.Data.SqlClient_.Models.DTOs
{
    public class TeamPlayerDTO : Player
    {
        public required int IdPlayerTeam { get; set; }
        public required int NumOnShirt { get; set; }
        [StringLength(300)]
        public string? Comment { get; set; } =null;
    }
}
