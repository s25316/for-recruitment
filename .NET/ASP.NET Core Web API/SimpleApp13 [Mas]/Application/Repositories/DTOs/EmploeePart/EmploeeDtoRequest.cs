namespace Application.Repositories.DTOs.EmploeePart
{
    public class EmploeeDtoRequest
    {
        public Guid Id { get; set; }
        public string Position { get; set; } = null!;
        public List<string> Competences { get; set; } = null!;
    }
}
