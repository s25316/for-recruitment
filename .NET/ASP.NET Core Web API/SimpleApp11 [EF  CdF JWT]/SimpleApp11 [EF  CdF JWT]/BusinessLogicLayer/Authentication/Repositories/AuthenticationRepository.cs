using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _iterationCountOfHashPassword = 10000;
        private readonly int _timeInMinutesValidJWT = 10;

        public AuthenticationRepository(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
            _secret = _configuration.GetSection("SecretKeys")["Secret1"]
                 ?? throw new InvalidOperationException("Secret Not Configured");
            _issuer = _configuration.GetSection("SecretKeys")["Issuer"]
                ?? throw new InvalidOperationException("Issuer Not Configured");
            _audience = _configuration.GetSection("SecretKeys")["Audience"]
                ?? throw new InvalidOperationException("Audience Not Configured");
        }

        public string GenerateSalt()
        {
            //Generate a 128-bit salt using secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        public string GenerateRefreshToken()
        {
            //Generate a 128-bit RefreshToken using secure PRNG
            byte[] salt = new byte[1024];
            using (var genNum = RandomNumberGenerator.Create())
            {
                genNum.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        public string HashPassword(string password, string salt)
        {
            //Password base key derivation function [Standard] - Pbkdf2
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
               password: password,
               salt: Convert.FromBase64String(salt),
               prf: KeyDerivationPrf.HMACSHA1,
               iterationCount: _iterationCountOfHashPassword,
               numBytesRequested: 256 / 8
               ));
        }
        
        //================================================================================================
                
        public (string, DateTime) GenerateJWTStringAndDateTimeValidTo
            (
            string name, 
            IEnumerable<string> roles
            )
        {
            var claims = GenerateClaims(name, roles);
            var token = GenerateJWT(claims);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            var validTo = token.ValidTo.ToLocalTime();
            return (tokenString, validTo);
        }

        private JwtSecurityToken GenerateJWT(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));

            var signing = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims.ToArray(),
                expires: DateTime.Now.ToLocalTime().AddMinutes(_timeInMinutesValidJWT),
                signingCredentials: signing
             );
        }

        private IEnumerable<Claim> GenerateClaims(string name, IEnumerable<string> roles) 
        {
            var claims = new List<Claim> {
                //Protect Before Replay attack
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name,name),
            };

            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }
            //new("Custom", "SomeData"),
            return claims;
        }

        //================================================================================================

        public bool IsJWTGeneratedByThisServer(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));

            try
            {
                tokenHandler.ValidateToken(jwt, new TokenValidationParameters
                {
                    ValidateIssuer = true, //I want validate, Who Give Token
                    ValidateAudience = true,//I want validate, For Who Given Token
                    ValidateLifetime = false,//I want to app to allowed Expired Tokens
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    IssuerSigningKey = secretKey,
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsJWTGeneratedByThisServerAndNotExpired(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));

            try
            {
                tokenHandler.ValidateToken(jwt, new TokenValidationParameters
                {
                    ValidateIssuer = true, //I want validate, Who Give Token
                    ValidateAudience = true,//I want validate, For Who Given Token
                    ValidateLifetime = true,//I want to app to allowed Expired Tokens
                    ValidateIssuerSigningKey = true,

                    //ClockSkew = TimeSpan.FromMinutes(1),// Time using for EXPIRED tokens TimeSpan.Zero
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    IssuerSigningKey = secretKey,
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Claim> GetClaimsFromJWT(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(jwt);
            var claims = jwtToken.Claims.ToList();
            return claims;
        }

        public string GetNameFromClaims(IEnumerable<Claim> claims)
        {
            var name = "";
            foreach (var claim in claims)
            {
                if (claim.Type == ClaimTypes.Name)
                {
                    name = claim.Value;
                    break;
                }
            }
            return name;
        }
    }
}
