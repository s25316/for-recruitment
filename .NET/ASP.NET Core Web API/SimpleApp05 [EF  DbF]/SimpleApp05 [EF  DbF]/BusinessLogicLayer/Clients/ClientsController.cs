using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp05__EF__DbF_.BusinessLogicLayer.Clients.DTOs;
using SimpleApp05__EF__DbF_.BusinessLogicLayer.Clients.Repositories;

namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsRepository _repository;
        public ClientsController(IClientsRepository repository) { _repository = repository;  }

        [HttpGet]
        public async Task<IActionResult> GetClientsAsync() 
        { 
            var result = await _repository.GetClientsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostClientAdync(PostClientDTO c) 
        {
            await _repository.PostClientAdync(c);
            return StatusCode(201);
        }

        [HttpPost("{IdClient:int}/Trips/{IdTrip:int}")]
        public async Task<IActionResult> PostConnectionClientTripAsync(int IdClient, int IdTrip, DateTime? PaymentDate) 
        {
            var result = await _repository.PostConnectionClientTripAsync(IdClient, IdTrip, PaymentDate);
            return StatusCode( (result? 201: 204) );
        }

        [HttpDelete("{IdClient:int}")]
        public async Task<IActionResult> DeleteClientByIdAsync(int IdClient) 
        {
            var result = await _repository.DeleteClientByIdAsync(IdClient);
            return StatusCode(( result ? 201 : 204));
        }
    }
}
