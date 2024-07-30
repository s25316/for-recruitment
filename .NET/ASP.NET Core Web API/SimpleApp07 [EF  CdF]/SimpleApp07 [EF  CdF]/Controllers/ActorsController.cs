using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp07__EF__CdF_.BusinessLogicLayer;
using SimpleApp07__EF__CdF_.BusinessLogicLayer.DTOs.Actor;
using System.ComponentModel.DataAnnotations;

namespace SimpleApp07__EF__CdF_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IFilmographyRepository _repository;
        public ActorsController(IFilmographyRepository repository) { _repository = repository; }

        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync()
        {
            var result = await _repository.GetActorsAsync();
            return StatusCode(200, result);
        }


        [HttpPost]
        public async Task<IActionResult> PostActorAsync(ActorPostDTO a) 
        {
            await _repository.PostActorAsync(a);
            return StatusCode(201);
        }
        [HttpPost("{IdActor:int}/Movies/{IdMovie:int}")]
        public async Task<IActionResult> PostActorMovieAsync(int IdActor, int IdMovie, [MaxLength(30)] string CharacterName)
        {
            await _repository.PostActorMovieAsync(IdActor, IdMovie, CharacterName);
            return StatusCode(201);
        }

    }
}
