using SimpleApp09__EF__CdF_.BusinessLogicLayer._Shared_DTOs;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.DTOs
{
    public class SongGetDTO
    {
        public int IdSong { get; set; }
        public string SongName { get; set; } = null!;
        public float Duration { get; set; }
        public virtual AlbumSharedGetDTO? Album { get; set; } = null;
        public virtual IEnumerable<MusicianSharedGetDTO> Musicians { get; set; } = new List<MusicianSharedGetDTO>();
    }
}
