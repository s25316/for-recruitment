namespace SimpleApp09__EF__CdF_.DatabaseLayer.Models
{
    public class Label
    {
        public int IdLabel { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
    }
}
