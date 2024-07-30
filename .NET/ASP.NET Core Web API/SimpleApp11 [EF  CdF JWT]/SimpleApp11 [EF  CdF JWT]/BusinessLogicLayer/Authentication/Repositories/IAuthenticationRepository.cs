using System.Security.Claims;

namespace SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Repositories
{
    public interface IAuthenticationRepository
    {
        string GenerateSalt();
        string GenerateRefreshToken();
        string HashPassword(string password, string salt);
        (string, DateTime) GenerateJWTStringAndDateTimeValidTo
            (
            string name,
            IEnumerable<string> roles
            );

        bool IsJWTGeneratedByThisServer(string jwt);
        bool IsJWTGeneratedByThisServerAndNotExpired(string jwt);
        IEnumerable<Claim> GetClaimsFromJWT(string jwt);
        string GetNameFromClaims(IEnumerable<Claim> claims);
    }
}
