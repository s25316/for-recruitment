namespace SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Models
{
    public class UserRefreshResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string? Comment { get; set; } = null;
        public string? JWT { get; set; } = null;
        public DateTime? JWTValidtTo { get; set; } = null;
        public string? RefreshToken { get; set; } = null;
        public DateTime? RefreshTokenValidTo { get; set; } = null;
    }
}
