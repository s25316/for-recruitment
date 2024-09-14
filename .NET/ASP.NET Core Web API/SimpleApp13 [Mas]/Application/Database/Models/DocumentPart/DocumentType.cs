namespace Application.Database.Models.DocumentPart
{
    public class DocumentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    }
}
