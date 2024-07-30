using SimpleApp09__EF__CdF_.BusinessLogicLayer._Shared_DTOs;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Musician.DTOs;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.DTOs
{
    public class SongSharedGetDTO
    {
        public int IdSong { get; set; }
        public string SongName { get; set; } = null!;
        public float Duration { get; set; }
        public virtual IEnumerable<MusicianSharedGetDTO> Musicians { get; set; } = new List<MusicianSharedGetDTO>();
    }
}
