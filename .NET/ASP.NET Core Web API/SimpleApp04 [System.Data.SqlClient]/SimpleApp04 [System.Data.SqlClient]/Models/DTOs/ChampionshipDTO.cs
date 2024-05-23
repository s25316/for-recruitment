using System.ComponentModel.DataAnnotations;

namespace SimpleApp04__System.Data.SqlClient_.Models.DTOs
{
    public class ChampionshipDTO 
    {
        public required int IdChampionship { get; set; }
        [StringLength(100)]
        public required string OfficialName { get; set; }
        public required int Year { get; set; }
        public IEnumerable<ChampionshipTeamDTO>? Teams { get; set; } = null;
    }
}
