namespace SimpleApp04__System.Data.SqlClient_.Models
{
    public class Championship_Team
    {
        public int IdChampionshipTeam { get; set; }
        public required int IdTeam { get; set; }
        public required int IdChampionship { get; set; }
        public required float Score { get; set; }
    }
}
