namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Label.DTOs
{
    public class LabelGetDTO
    {
        public int IdLabel { get; set; }
        public string Name { get; set; } = null!;
        public virtual IEnumerable<LabelAlbumGetDTO>  Albums { get; set; } = new List<LabelAlbumGetDTO>();
    }
}
