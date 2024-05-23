using SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.DTOs;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Songs.DTOs;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.Repositories
{
    public interface ISongsRepository
    {
        Task<IEnumerable<SongGetDTO>> GetSongsAsync();
        Task<bool> PostSongAsync(SongPostDTO song);
        Task<bool> DeleteSongAsync(int IdSong);
    }
}
