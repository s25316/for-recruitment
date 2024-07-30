namespace SimpleApp10__EF__CdF_JWT_.DatabaseLayer.Models
{
    public class Person
    {
        public Guid IdPearson { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Salt { get; set; } = null!;
        
        public string? JWT { get; set; } = null;
        public DateTime? JWTValidTo { get; set; } = null;
        public string? RefreshToken { get; set; } = null;
        public DateTime? RefreshTokentValidTo { get; set; } = null;
    }
}
