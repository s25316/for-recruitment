using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private IAnimalsRepository _animalsRepository;

        public AnimalsController(IAnimalsRepository animalsRepository) 
        {
            _animalsRepository = animalsRepository;
        }

        [HttpGet]
        public async Task <ActionResult> GetAllAnimals(string orderBy)
        {
            var animals = await _animalsRepository.GetAnimals(orderBy);
            return Ok(animals);
        }
        [HttpPost]
        public async Task<ActionResult> PostAnimal( PutAnimalDTO a)
        {
            var x = await _animalsRepository.PostAnimalAsync(a);
            return Ok(x);
        }
        [HttpPut("{IdAnimal}")]
        public async Task<ActionResult> PutAnimal(int IdAnimal, PutAnimalDTO a)
        {
            var x = await _animalsRepository.PutAnimalAsync(IdAnimal, a);
            return Ok(x);
        }
        [HttpDelete ("{IdAnimal}")]
        public async Task<ActionResult> DeleteAnimal(int IdAnimal)
        {
            var x = await _animalsRepository.DeleteAnimalAsync(IdAnimal);
            return Ok(x);
        }
    }
}
