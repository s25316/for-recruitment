namespace SimpleApp04__System.Data.SqlClient_.Models.DTOs
{
    public class ChampionshipTeamDTO : Team
    {
        public int IdChampionshipTeam { get; set; }
        public required float Score { get; set; }
    }
}
