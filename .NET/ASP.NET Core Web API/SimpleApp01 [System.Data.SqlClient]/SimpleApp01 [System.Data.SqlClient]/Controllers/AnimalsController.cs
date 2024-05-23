using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp01__System.Data.SqlClient_.Entities;
using SimpleApp01__System.Data.SqlClient_.Models.DTOs;

namespace SimpleApp01__System.Data.SqlClient_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepository _animalsRepository;

        public AnimalsController(IAnimalsRepository animalsRepository)
        {
            _animalsRepository = animalsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimalsAsync()
        {
            var request = await _animalsRepository.GetAnimalsAsync();
            if (request.HasValue) 
            { 
                return Ok(request.Value);
            }
            return StatusCode(request.Code);
        }

        [HttpPost]
        public async Task<IActionResult> PostAnimalAsync(AnimalDTO a)
        {
            var request = await _animalsRepository.PostAnimalAsync(a);
            return StatusCode(request.Code);
        }

        [HttpPut("{IdAnimal:int}")]
        public async Task<IActionResult> PutAnimalAsync(int IdAnimal, AnimalDTO a) 
        {
            var request = await _animalsRepository.PutAnimalAsync(IdAnimal, a);
            return StatusCode( request.Code );
        }

        [HttpDelete("{IdAnimal:int}")]
        public async Task<IActionResult> DeleteAnimalAsync(int IdAnimal)
        {
            var request = await _animalsRepository.DeleteAnimalAsync(IdAnimal);
            return StatusCode(request.Code);
        }


    }
}
