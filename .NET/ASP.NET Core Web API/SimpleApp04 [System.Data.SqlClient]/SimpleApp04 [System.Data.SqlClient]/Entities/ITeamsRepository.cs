using SimpleApp04__System.Data.SqlClient_.Models.DTOs;
using SimpleApp04__System.Data.SqlClient_.Models;
using System.Threading.Tasks;

namespace SimpleApp04__System.Data.SqlClient_.Entities
{
    public interface ITeamsRepository
    {
        Task<Request<List<ChampionshipDTO>>> GetChampionshipDetailsAsync(int? IdChampionship);
        Task<Request<List<TeamDTO>>> GetTeamsDetailsAsync(int? IdTeam);
        Task<Request<string>> PostPlayerTeamAsync(int IdTeam, int IdPlayer, Player_TeamDTO pt);
    }
}
