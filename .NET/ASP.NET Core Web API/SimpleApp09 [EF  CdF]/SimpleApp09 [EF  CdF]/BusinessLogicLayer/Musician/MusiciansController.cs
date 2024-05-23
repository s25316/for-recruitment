using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Musician.DTOs;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Musician.Repositories;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Musician
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly IMusicianRepository _repository;
        public MusiciansController(IMusicianRepository repository) { _repository = repository; }
        
        [HttpGet]
        public async Task<IActionResult> GetMusicanAsync()
        {
            var result = await _repository.GetMusicanAsync();
            return StatusCode(200, result);
        }
        [HttpPost]
        public async Task<IActionResult> PostMusicianAsync(MusicianPostDTO musician) 
        {
            await _repository.PostMusicianAsync(musician);
            return StatusCode(201);
        }

        [HttpDelete("{IdMusician:int}")]
        public async Task<IActionResult> DeleteMusicianAsync(int IdMusician) 
        { 
            var result = await _repository.DeleteMusicianAsync(IdMusician); 
            return result? StatusCode(202) : StatusCode(404);
        }

        [HttpPost("{IdMusician:int}/Songs/{IdSong:int}")]
        public async Task<IActionResult> PostMusicianSongAsync(int IdMusician, int IdSong) 
        {
            var result = await _repository.PostMusicianSongAsync(IdMusician, IdSong);
            return result ? StatusCode(202) : StatusCode(404);
        }
    }
}
