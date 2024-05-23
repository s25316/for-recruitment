using SimpleApp09__EF__CdF_.BusinessLogicLayer._Shared_DTOs;
using System.ComponentModel.DataAnnotations;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Album.DTOs
{
    public class AlbumPostDTO
    {
        [Required]
        [StringLength(30)]
        public string NameAlbum { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public int IdLabel { get; set; }
    }
}
