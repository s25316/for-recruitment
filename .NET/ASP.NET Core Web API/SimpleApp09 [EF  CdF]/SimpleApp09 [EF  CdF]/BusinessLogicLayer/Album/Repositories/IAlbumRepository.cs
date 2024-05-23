using SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.DTOs;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.Repositories
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<AlbumGetDTO>> GetAlbumsAsync();
        Task<bool> PostAlbumAsync(AlbumPostDTO album);
        Task<bool> DeleteAlbumAsync(int IdAlbum);
    }
}
