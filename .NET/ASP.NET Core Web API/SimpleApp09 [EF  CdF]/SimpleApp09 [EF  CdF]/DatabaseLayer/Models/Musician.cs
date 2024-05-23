namespace SimpleApp09__EF__CdF_.DatabaseLayer.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Nickname { get; set; } = null;

        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();    
    }
}
