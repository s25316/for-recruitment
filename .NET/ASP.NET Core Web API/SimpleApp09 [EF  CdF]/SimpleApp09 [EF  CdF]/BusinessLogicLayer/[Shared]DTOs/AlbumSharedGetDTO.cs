namespace SimpleApp09__EF__CdF_.BusinessLogicLayer._Shared_DTOs
{
    public class AlbumSharedGetDTO
    {
        public int IdAlbum { get; set; }
        public string NameAlbum { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public LabelSharedGetDTO Label { get; set; } = null !;
    }
}
