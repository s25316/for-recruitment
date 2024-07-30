using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp05__EF__DbF_.BusinessLogicLayer.Countries.Repositories;

namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Countries
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesRepository _repository;
        public CountriesController(ICountriesRepository repository) { _repository = repository;  }

        [HttpGet]
        public async Task<IActionResult> GetCountriesAsync() 
        { 
            var result = await _repository.GetCountriesAsync();
            return Ok(result); 
        }
        
        [HttpPost]
        public async Task<IActionResult> PostCountryAsync(string CountryName) 
        {
            await _repository.PostCountryAsync(CountryName);
            return StatusCode(201);
        }

        [HttpPost("{IdCountry:int}/Trips/{IdTrip:int}")]
        public async Task<IActionResult> PostConnectionCountryTripAsync(int IdCountry, int IdTrip) 
        {
            var result = await _repository.PostConnectionCountryTripAsync(IdCountry, IdTrip);
            return StatusCode((result ? 201 : 204));
        }

        [HttpDelete("{IdCountry:int}")]
        public async Task<IActionResult> DeleteCountryByIdAsync(int IdCountry) 
        {
            var result = await _repository.DeleteCountryByIdAsync(IdCountry);
            return StatusCode((result ? 201 : 204));
        }
    }
}
