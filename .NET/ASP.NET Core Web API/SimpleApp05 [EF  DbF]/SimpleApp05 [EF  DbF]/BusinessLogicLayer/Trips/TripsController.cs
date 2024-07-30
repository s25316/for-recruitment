using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp05__EF__DbF_.BusinessLogicLayer.Clients.Repositories;
using SimpleApp05__EF__DbF_.BusinessLogicLayer.Countries.Repositories;
using SimpleApp05__EF__DbF_.BusinessLogicLayer.Trips.DTOs;
using SimpleApp05__EF__DbF_.BusinessLogicLayer.Trips.Repositories;

namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Trips
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsRepository _repository;
        private readonly ICountriesRepository _countriesRepository;
        private readonly IClientsRepository _clientsRepository;
        public TripsController (ITripsRepository repository, ICountriesRepository countries, IClientsRepository clients) 
        { 
            _repository = repository;
            _countriesRepository = countries;
            _clientsRepository = clients;
        }

        [HttpGet]
        public async Task<IActionResult> GetTripsAsync()
        { 
            var result = await _repository.GetTripsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostTripAsync(PostTripDTO t) 
        {
            var result = await _repository.PostTripAsync(t);
            return StatusCode(201);
        }

        [HttpPost("{IdTrip:int}/Clients/{IdClient:int}")]
        public async Task<IActionResult> PostConnectionClientTripAsync(int IdClient, int IdTrip, DateTime? PaymentDate)
        {
            var result = await _clientsRepository.PostConnectionClientTripAsync(IdClient, IdTrip, PaymentDate);
            return StatusCode((result ? 201 : 204));
        }


        [HttpPost("{IdTrip:int}/Countries/{IdCountry:int}")]
        public async Task<IActionResult> PostConnectionCountryTripAsync(int IdCountry, int IdTrip)
        {
            var result = await _countriesRepository.PostConnectionCountryTripAsync(IdCountry, IdTrip);
            return StatusCode((result ? 201 : 204));
        }

        [HttpDelete("{IdTrip:int}")]
        public async Task<IActionResult> DeleteTripByIdAsync(int IdTrip) 
        {
            var result = await _repository.DeleteTripByIdAsync(IdTrip);
            return StatusCode( result ? 201 : 204);
        }
    }
}
