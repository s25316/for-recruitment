namespace SimpleApp09__EF__CdF_.DatabaseLayer.Models
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public string NameAlbum { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public int IdLabel { get; set; }

        public virtual Label Label { get; set; } = null!;
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
