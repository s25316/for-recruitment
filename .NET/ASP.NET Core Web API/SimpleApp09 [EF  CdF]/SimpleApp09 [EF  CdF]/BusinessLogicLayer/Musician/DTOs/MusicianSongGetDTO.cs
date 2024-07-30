using SimpleApp09__EF__CdF_.BusinessLogicLayer._Shared_DTOs;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Musician.DTOs
{
    public class MusicianSongGetDTO
    {
        public int IdSong { get; set; }
        public string SongName { get; set; } = null!;
        public float Duration { get; set; }
        public virtual AlbumSharedGetDTO? Album { get; set; } = null;
    }
}
