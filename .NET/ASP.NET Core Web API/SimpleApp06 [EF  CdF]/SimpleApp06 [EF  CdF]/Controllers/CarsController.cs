using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp06__EF__CdF_.BusinessLogicLayer;
using SimpleApp06__EF__CdF_.BusinessLogicLayer.DTOs;

namespace SimpleApp06__EF__CdF_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsRepository _repository;
        public CarsController (ICarsRepository repository) { _repository = repository; }

        [HttpGet]
        public async Task<IActionResult> GetGarsAsync() 
        { 
            var result = await _repository.GetCarsAsync();
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> PostCarAsync(CarPostDTO c) 
        { 
            await _repository.PostCarAsync(c);
            return StatusCode(201);
        }

        [HttpPost("{IdCar:int}/Person/{IdPerson:int}")]
        public async Task<IActionResult> PostCarPersonAsync(int IdCar, int IdPerson, bool MainOwner) 
        { 
            await _repository.PostCarPersonAsync(IdCar, IdPerson, MainOwner);
            return StatusCode(201);
        }
    }
}
