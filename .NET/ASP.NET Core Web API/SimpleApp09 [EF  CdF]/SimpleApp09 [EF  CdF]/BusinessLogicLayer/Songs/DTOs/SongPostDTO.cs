using SimpleApp09__EF__CdF_.BusinessLogicLayer._Shared_DTOs;
using System.ComponentModel.DataAnnotations;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Songs.DTOs
{
    public class SongPostDTO
    {
        [Required]
        [StringLength(30)]
        public string SongName { get; set; } = null!;
        [Range(0 , float.MaxValue)]
        public float Duration { get; set; }
        public int? IdAlbum { get; set; } = null;
    }
}
