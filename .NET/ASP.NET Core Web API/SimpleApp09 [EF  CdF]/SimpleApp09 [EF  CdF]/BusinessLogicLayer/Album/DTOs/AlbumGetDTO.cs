using SimpleApp09__EF__CdF_.BusinessLogicLayer._Shared_DTOs;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.DTOs
{
    public class AlbumGetDTO
    {
        public int IdAlbum { get; set; }
        public string NameAlbum { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public virtual LabelSharedGetDTO Label { get; set; } = null!;
        public virtual IEnumerable<SongSharedGetDTO> Songs { get; set; } = new List<SongSharedGetDTO>();  
    }
}
