using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.Repositories;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Musician.Repositories;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Songs.DTOs;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Album
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongsRepository _repository;
        private readonly IMusicianRepository _musicianRepository;
        public SongsController(ISongsRepository repository, IMusicianRepository musicianRepository)
        {
            _repository = repository;
            _musicianRepository = musicianRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _repository.GetSongsAsync();
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> PostSongAsync(SongPostDTO song)
        {
            var result = await _repository.PostSongAsync(song);
            return (result)? StatusCode(201): StatusCode(404);
        }
        
        [HttpDelete("{IdSong:int}")]
        public async Task<IActionResult> DeleteSongAsync(int IdSong)
        {
            var result = await _repository.DeleteSongAsync(IdSong);
            return (result) ? StatusCode(202) : StatusCode(404);
        }
        
        [HttpPost("{IdSong:int}/Musicans/{IdMusician:int}")]
        public async Task<IActionResult> PostMusicianSongAsync(int IdMusician, int IdSong)
        {
            var result = await _musicianRepository.PostMusicianSongAsync(IdMusician, IdSong);
            return result ? StatusCode(202) : StatusCode(404);
        }
    }
}
