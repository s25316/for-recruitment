using SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.DTOs;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Label.DTOs
{
    public class LabelAlbumGetDTO
    {
        public int IdAlbum { get; set; }
        public string NameAlbum { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public virtual IEnumerable<SongSharedGetDTO> Songs { get; set; } = new List<SongSharedGetDTO>();    
    }
}
