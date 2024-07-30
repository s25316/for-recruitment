using System.ComponentModel.DataAnnotations;

namespace SimpleApp04__System.Data.SqlClient_.Models
{
    public class Player_Team
    {
        public int IdPlayerTeam { get; set; }
        public required int IdPlayer { get; set; }
        public required int IdTeam { get; set; }
        public required int NumOnShirt { get; set; }
        [StringLength(300)]
        public string? Comment { get; set; }

    }
}
