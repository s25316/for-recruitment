using Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApp13__MAS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly IUseCasesRepository _repository;

        public AdressesController(IUseCasesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{nazwa}")]
        public async Task<IActionResult> GetDivisionsAsync(string nazwa)
        {
            var result = await _repository.GetDivisionsAsync(nazwa);
            return Ok(result);
        }

        [HttpGet("{id:int}/up")]

        public async Task<IActionResult> GetDivisionsUpByDivisionAsync(int id)
        {
            var result = await _repository.GetDivisionsUpByDivisionAsync(id);
            return Ok(result);
        }

        [HttpGet("{divisionId}/streets")]
        public async Task<IActionResult> GetStreetsByDivisionIdAsync(long divisionId)
        {
            var result = await _repository.GetStreetsByDivisionIdAsync(divisionId);
            return Ok(result);
        }

    }
}
