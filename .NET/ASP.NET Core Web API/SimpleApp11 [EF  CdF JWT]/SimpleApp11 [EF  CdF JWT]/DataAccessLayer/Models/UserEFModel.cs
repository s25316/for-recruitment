namespace SimpleApp11__EF__CdF_JWT_.DataAccessLayer.Models
{
    public class UserEFModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Passsword { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public string? Refresh {  get; set; } = null;
        public DateTime? DeactivationDate { get; set; } = null;
    }
}
