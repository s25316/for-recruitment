namespace Application.Repositories.DTOs.DocumentPart
{
    public class DocumentDtoRequest
    {
        public string Number { get; set; } = null!;
        public string Country { get; set; } = null!;
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public int DocumentTypeId { get; set; }
    }
}
