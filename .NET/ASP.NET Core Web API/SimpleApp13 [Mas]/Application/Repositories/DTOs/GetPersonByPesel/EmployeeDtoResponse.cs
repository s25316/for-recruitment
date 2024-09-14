namespace Application.Repositories.DTOs.GetPersonByPesel
{
    public class EmployeeDtoResponse
    {
        public Guid Id { get; set; }
        public string Position { get; set; } = null!;
        public IEnumerable<string> Competences { get; set; } = new List<string>();
    }
}
