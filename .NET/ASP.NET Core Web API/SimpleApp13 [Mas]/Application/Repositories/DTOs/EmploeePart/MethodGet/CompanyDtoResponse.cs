namespace Application.Repositories.DTOs.EmploeePart.MethodGet
{
    public class CompanyDtoResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Nip { get; set; } = null; //Nie wszytskie firmy moga posiadac 
        public string? Regon { get; set; } = null; //Nie wszytskie firmy
        public string Status { get; set; } = null!;
        public bool IsOurClient { get; set; }
        public string? Email { get; set; } = null;
    }
}
