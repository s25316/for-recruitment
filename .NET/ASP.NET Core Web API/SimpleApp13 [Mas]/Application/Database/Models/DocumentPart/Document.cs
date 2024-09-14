using Application.Database.Models.PersonPart;

namespace Application.Database.Models.DocumentPart
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = null!;
        public string Country { get; set; } = null!;
        public DateTime From { get; set; }
        public DateTime? To { get; set; }

        //FK DocumentType
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; } = null!;
        //FK Person
        public Guid PersonId { get; set; }
        public Person Person { get; set; } = null!;
    }
}
