using System.ComponentModel.DataAnnotations;

namespace SimpleApp04__System.Data.SqlClient_.Models.DTOs
{
    public class TeamDTO
    {
        public required int IdTeam { get; set; }
        [StringLength(30)]
        public required string TeamName { get; set; }
        public required int MaxAge { get; set; }
        public IEnumerable<TeamPlayerDTO>? Players { get; set; } = null;
    }
}
