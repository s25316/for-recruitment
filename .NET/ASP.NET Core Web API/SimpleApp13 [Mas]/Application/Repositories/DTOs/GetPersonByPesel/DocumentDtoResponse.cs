namespace Application.Repositories.DTOs.GetPersonByPesel
{
    public class DocumentDtoResponse
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = null!;
        public string Country { get; set; } = null!; //Polska 
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public string DocumentType { get; set; } = null!;
    }
}
