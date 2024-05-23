namespace SimpleApp10__EF__CdF_JWT_.BusinessLogicLayer.Authentication.DTOs
{
    public class JWTResponseDTO
    {
        public string JWT { get; set; } = null!;
        public DateTime JWTValidTo { get; set; }
        public string RefreshToken { get; set; } = null!;
        public DateTime RefreshTokenValidTo { get; set; }
    }
}
