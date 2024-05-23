using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp04__System.Data.SqlClient_.Entities;
using SimpleApp04__System.Data.SqlClient_.Models.DTOs;

namespace SimpleApp04__System.Data.SqlClient_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsRepository _teamsRepository;
        public TeamsController(ITeamsRepository teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }
        /*Teams Part*/
        [HttpGet]
        public async Task<IActionResult> GetTeamsDetailsAsync()
        {
            var result = await _teamsRepository.GetTeamsDetailsAsync(-1);
            return StatusCode(result.Code, result.IsExistValue ? result.Value : null);
        }
        [HttpPost("{IdTeam:int}/Players/{IdPlayer:int}")]
        public async Task<IActionResult> PostPlayerToTeamAsync(int IdTeam, int IdPlayer, Player_TeamDTO pt) 
        {
            var result = await _teamsRepository.PostPlayerTeamAsync(IdTeam, IdPlayer, pt);
            return StatusCode(result.Code, result.IsExistValue ? result.Value : null);
        }
        /*Championships Part*/
        [HttpGet("Championships")]
        public async Task<IActionResult> GetChampionshipsDetailsAsync()
        {
            var request = await _teamsRepository.GetChampionshipDetailsAsync(-1);
            return StatusCode(request.Code, request.IsExistValue ? request.Value : null);
        }
        [HttpGet("Championships/{IdChampionship:int}")]
        public async Task <IActionResult> GetChampionshipDetailsAsync(int IdChampionship) 
        {
            if (IdChampionship < 0) 
            {
                return BadRequest($"IdChampionship must be more 0 not: {IdChampionship}");
            }
            var request = await _teamsRepository.GetChampionshipDetailsAsync(IdChampionship);
            return StatusCode(request.Code, request.IsExistValue? request.Value : null);
        }
        
    }
}
