using SimpleApp09__EF__CdF_.BusinessLogicLayer.Musician.DTOs;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Musician.Repositories
{
    public interface IMusicianRepository
    {
        Task<IEnumerable<MusicianGetDTO>> GetMusicanAsync();
        Task<bool> PostMusicianAsync(MusicianPostDTO musician);
        Task<bool> DeleteMusicianAsync(int IdMusician);
        Task<bool> PostMusicianSongAsync(int IdMusician, int IdSong);
    }
}
