using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp07__EF__CdF_.BusinessLogicLayer;
using SimpleApp07__EF__CdF_.BusinessLogicLayer.DTOs.Movie;
using System.ComponentModel.DataAnnotations;

namespace SimpleApp07__EF__CdF_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IFilmographyRepository _repository;
        public MoviesController (IFilmographyRepository repository) { _repository = repository; }

        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync() 
        {
            var result = await _repository.GetMoviesAsync();
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> PostMovieAsync(MoviePostDTO m) 
        {
            await _repository.PostMovieAsync(m);
            return StatusCode(201);
        }

        [HttpPost("{IdMovie:int}/Actors/{IdActor:int}")]
        public async Task<IActionResult> PostActorMovieAsync(int IdActor, int IdMovie, [MaxLength(30)] string CharacterName ) 
        {
            await _repository.PostActorMovieAsync(IdActor, IdMovie, CharacterName);
            return StatusCode(201);
        }
    }
}
