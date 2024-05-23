using System.ComponentModel.DataAnnotations;

namespace SimpleApp04__System.Data.SqlClient_.Models
{
    public class Team
    {
        public int IdTeam { get; set; }
        [StringLength(30)]
        public required string TeamName { get; set; }
        public required int MaxAge { get; set; }
    }
}
