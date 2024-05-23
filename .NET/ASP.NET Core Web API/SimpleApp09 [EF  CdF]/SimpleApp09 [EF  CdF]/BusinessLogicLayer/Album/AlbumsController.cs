using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.DTOs;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.Repositories;
using SimpleApp09__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Album
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumRepository _repository;
        public AlbumsController (IAlbumRepository repository) { _repository = repository; }

        [HttpGet]
        public async Task<IActionResult> GetAlbumsAsync() 
        {
            var result = await _repository.GetAlbumsAsync();
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAlbumAsync(AlbumPostDTO album) 
        {
            var result = await _repository.PostAlbumAsync(album);
            return (result)? StatusCode(201) : StatusCode(404);
        }

        [HttpDelete("{IdAlbum:int}")]
        public async Task<IActionResult> DeleteAlbumAsync(int IdAlbum) 
        {
            var result = await _repository.DeleteAlbumAsync(IdAlbum);
            return (result) ? StatusCode(202) : StatusCode(404);
        }
    }
}
