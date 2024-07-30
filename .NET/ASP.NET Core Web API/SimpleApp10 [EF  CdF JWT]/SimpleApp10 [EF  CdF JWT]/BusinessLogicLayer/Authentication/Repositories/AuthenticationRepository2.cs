using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using SimpleApp10__EF__CdF_JWT_.BusinessLogicLayer.Authentication.DTOs;
using SimpleApp10__EF__CdF_JWT_.DatabaseLayer.Models;
using SimpleApp10__EF__CdF_JWT_.DatabaseLayer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SimpleApp10__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Repositories
{
    public class AuthenticationRepository2 : IAuthenticationRepository
    {
        //Magic Numbers
        private readonly int _iterationCountOfHashPassword = 10000;

        private readonly IConfiguration _configuration;
        private readonly LibraryDBContext _context;
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;
        public AuthenticationRepository2(IConfiguration configuration, LibraryDBContext context)
        {
            _configuration = configuration;
            _context = context;
            _secret = configuration.GetSection("SecretKeys")["SecretKey1"]
                ?? throw new InvalidOperationException("Secret Not Configured");
            _issuer = configuration.GetSection("JWT")["Issuer1"]
                ?? throw new InvalidOperationException("Issuer Not Configured");
            _audience = configuration.GetSection("JWT")["Audience1"]
                ?? throw new InvalidOperationException("Audience Not Configured");
        }

        private string GenerateSalt()
        {
            //Generate a 128-bit salt using secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        private string GenerateRefreshToken()
        {
            //Generate a 128-bit RefreshToken using secure PRNG
            byte[] salt = new byte[1024];
            using (var genNum = RandomNumberGenerator.Create())
            {
                genNum.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        private string HashPassword(string password, string salt)
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

        private JwtSecurityToken GenerateTokenJWT(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));

            var signing = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims.ToArray(),
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signing
             );
        }
        //=====================================================================================
        private IEnumerable<Claim> GenerateClaims(Person person)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, person.Email));
            //Protect Before Replay attack
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            return claims;
        }

        private JWTResponseDTO? GetJWTAndRefreshTokenFromPerson(Person person)
        {
            if (person.JWT != null && person.RefreshToken != null &&
               person.JWTValidTo != null && person.RefreshTokentValidTo != null &&
               person.JWTValidTo > DateTime.Now.ToLocalTime() &&
               person.RefreshTokentValidTo > DateTime.Now.ToLocalTime())
            {
                return new JWTResponseDTO
                {
                    JWT = person.JWT,
                    JWTValidTo = (DateTime)person.JWTValidTo,
                    RefreshToken = person.RefreshToken,
                    RefreshTokenValidTo = (DateTime)person.RefreshTokentValidTo
                };
            }
            else return null;
        }

        private async Task SetJWTAndRefreshTokenToPersonAsync
            (Person person, JwtSecurityToken jwt, CancellationToken cancellation)
        {
            person.JWT = new JwtSecurityTokenHandler().WriteToken(jwt);
            person.JWTValidTo = jwt.ValidTo.ToLocalTime();


            person.RefreshToken = GenerateRefreshToken();
            person.RefreshTokentValidTo = DateTime.Now.AddHours(12).ToLocalTime();

            await _context.SaveChangesAsync(cancellation);
        }

        private async Task SetJWTToPersonAsync
            (Person person, JwtSecurityToken jwt, CancellationToken cancellation)
        {
            person.JWT = new JwtSecurityTokenHandler().WriteToken(jwt);
            person.JWTValidTo = jwt.ValidTo.ToLocalTime();

            await _context.SaveChangesAsync(cancellation);
        }


        //=====================================================================================
        public async Task<Tuple<bool, string>> CreatePersonAsync
            (PersonRegistrationRequestDTO person, CancellationToken cancellation)
        {
            var user = await _context.People.Where(p => p.Email == person.Email)
                .FirstOrDefaultAsync(cancellation);
            if (user != null)
            { return new Tuple<bool, string>(false, "Use another email"); }

            var salt = GenerateSalt();
            var hashedPassword = HashPassword(person.Password, salt);

            await _context.People.AddAsync(new DatabaseLayer.Models.Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Password = hashedPassword,
                Salt = salt,
            }, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return new Tuple<bool, string>(true, "Create");
        }

        public async Task<ResponseDTO<JWTResponseDTO>> LoginAsync
             (PersonLoginRequestDTO person, CancellationToken cancellation)
        {
            /*
            1 Find User => Exist \ Not Exist

            2 Check JWT => Valid \ Not Valid
            2.1 Valid => return from DB
            2.2 Not Valid => Generate with RT
            2.2.1 Save DB & return val           
             */
            var response = new ResponseDTO<JWTResponseDTO>()
            {
                IsSuccess = false,
                Message = "Ucorrect data"
            };
            //Not exist User
            var user = await _context.People.Where(p => p.Email == person.Email)
                .FirstOrDefaultAsync(cancellation);
            if (user == null) { return response; }

            //Not correct Password
            var hashGotPassword = HashPassword(person.Password, user.Salt);
            if (hashGotPassword != user.Password) { return response; }

            //Change data response baceuse is correct data
            response.IsSuccess = true;
            response.Message = "Sucess";

            var jwt = GetJWTAndRefreshTokenFromPerson(user);
            if (jwt != null)
            {
                response.Value = jwt;
                return response;
            }

            var claims = GenerateClaims(user);
            var token = GenerateTokenJWT(claims);
            await SetJWTAndRefreshTokenToPersonAsync(user, token, cancellation);

            jwt = GetJWTAndRefreshTokenFromPerson(user);

            response.Value = jwt;
            return response;
        }

        public async Task<ResponseDTO<JWTResponseDTO>> GetJWTByRefreshTokenAsync
            (string refresh, CancellationToken cancellation)
        {
            /*
            1 Find User WIth RT => Exist \ Not Exist
            
            2 Check JWT => Valid \ Not Valid
            2.1 Valid => return
            2.2 Not Valid => Generate JWT 

            3 Update DB only JWT data
             */
            var response = new ResponseDTO<JWTResponseDTO>()
            {
                IsSuccess = false,
                Message = "Not Corect Data"
            };

            var user = await _context.People.Where(x => x.RefreshToken == refresh)
                .FirstOrDefaultAsync(cancellation);
            if (user == null) { return response; }

            response.Message = "Token InValid";
            if (user.RefreshTokentValidTo <= DateTime.Now.ToLocalTime()) { return response; }

            //Change data response baceuse is correct data
            response.IsSuccess = true;
            response.Message = "Sucess";

            var jwt = GetJWTAndRefreshTokenFromPerson(user);
            if (jwt != null)
            {
                response.Value = jwt;
                return response;
            }

            var claims = GenerateClaims(user);
            var token = GenerateTokenJWT(claims);
            await SetJWTToPersonAsync(user, token, cancellation);

            jwt = GetJWTAndRefreshTokenFromPerson(user);

            response.Value = jwt;
            return response;
        }

        public async Task<Tuple<bool, string>> LogoutAsync(string email, CancellationToken cancellation)
        {
            var user = await _context.People.Where(u => u.Email == email)
                .FirstOrDefaultAsync(cancellation);
            if (user == null) { return new Tuple<bool, string>(false, "User not Exist"); }

            user.JWT = null;
            user.JWTValidTo = null;
            user.RefreshToken = null;
            user.RefreshTokentValidTo = null;
            await _context.SaveChangesAsync(cancellation);

            return new Tuple<bool, string>(true, "Logout");
        }
    }
}
