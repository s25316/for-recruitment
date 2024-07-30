namespace SimpleApp09__EF__CdF_.DatabaseLayer.Models
{
    public class Song
    {
        public int IdSong { get; set; }
        public string SongName { get; set; } = null!;
        public float Duration { get; set; }
        public int? IdAlbum { get; set; } = null;

        public virtual Album? Album { get; set; } = null;
        public virtual ICollection<Musician> Musicians { get; set; } = new List<Musician>();    
    }
}
