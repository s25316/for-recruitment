using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp06__EF__CdF_.BusinessLogicLayer;
using SimpleApp06__EF__CdF_.BusinessLogicLayer.DTOs;

namespace SimpleApp06__EF__CdF_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly ICarsRepository _repository;
        public PeopleController (ICarsRepository repository) { _repository = repository; }

        [HttpGet]
        public async Task<IActionResult> GetPeopleAsync() 
        {
            var result = await _repository.GetPeopleAsync();
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> PostPersonAsync(PersonPostDTO p) 
        {
            await _repository.PostPearsonAsync(p);
            return StatusCode(201);
        }

        [HttpPost("{IDPerson:int}/Cars/{IdCar:int}")]
        public async Task<IActionResult> PostCarPersonAsync(int IdCar, int IdPerson, bool MainOwner)
        {
            await _repository.PostCarPersonAsync(IdCar, IdPerson, MainOwner);
            return StatusCode(201);
        }
    }
}
