namespace Application.Repositories.DTOs.GetPersonByPesel
{
    public class ClientDtoResponse
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; } = null!;
        public EmployeeDtoResponse? AccountManager { get; set; } = null;
    }
}
