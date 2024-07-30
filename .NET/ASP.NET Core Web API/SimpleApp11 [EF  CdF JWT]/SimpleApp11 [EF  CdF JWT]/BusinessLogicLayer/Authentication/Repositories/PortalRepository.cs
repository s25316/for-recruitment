using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Models;
using SimpleApp11__EF__CdF_JWT_.DataAccessLayer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Repositories
{
    public class PortalRepository : IPortalRepository
    {
        private readonly PortalDBContext _dbContext;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly int _timeInHoursValidRefershToken = 48;

        //Constructor 
        public PortalRepository(
            PortalDBContext dbContext,
            IAuthenticationRepository authenticationRepository
            ) 
        { 
            _dbContext = dbContext; 
            _authenticationRepository = authenticationRepository;
        }

        //Methods
        public async Task<UserCreateResponseDTO> UserCreateAsync
            (
            UserCreateRequestDTO request, 
            CancellationToken cancellation
            ) 
        {
            var user = await _dbContext.Users.Where(x => x.Email == request.Email).FirstOrDefaultAsync();
            if ( user != null ) 
            {
                return new UserCreateResponseDTO 
                { 
                    IsSuccess = false,
                    Message = "Choose other Email",
                };
            }

            var salt = _authenticationRepository.GenerateSalt();
            var hashPassword = _authenticationRepository.HashPassword(request.Passsword, salt);

            await _dbContext.Users.AddAsync(new DataAccessLayer.Models.UserEFModel 
            { 
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Salt = salt,
                Passsword = hashPassword,
            }, cancellation);
            await _dbContext.SaveChangesAsync(cancellation);    

            return new UserCreateResponseDTO 
            { 
                IsSuccess = true,
                Message = "Created",
            };
        }


        public async Task<UserLoginResponseDTO> LoginInAsync
            (
            UserLoginRequestDTO request, 
            CancellationToken cancellation
            )
        {
            var user = await _dbContext.Users.Where(x => x.Email == request.Email).FirstOrDefaultAsync(cancellation);
            if (user == null)
            {
                return new UserLoginResponseDTO
                {
                    IsSuccess = false,
                    Comment = "Uncorrect Data",
                };
            }

            var requestPasswordHashed = _authenticationRepository.HashPassword(request.Password, user.Salt);
            if (requestPasswordHashed != user.Passsword) 
            {
                return new UserLoginResponseDTO
                {
                    IsSuccess = false,
                    Comment = "Uncorrect Data",
                };
            }

            var jwt = _authenticationRepository.GenerateJWTStringAndDateTimeValidTo
                (user.Id.ToString(), new List<string>() { "user" });

            if (string.IsNullOrEmpty(user.Refresh) || user.DeactivationDate == null) 
            {
                var refresh = _authenticationRepository.GenerateRefreshToken();
                var refreshValidTo = DateTime.Now.ToLocalTime().AddHours(_timeInHoursValidRefershToken);

                user.Refresh = refresh;
                user.DeactivationDate = refreshValidTo;
                await _dbContext.SaveChangesAsync(cancellation);
            }           

            return new UserLoginResponseDTO 
            { 
                IsSuccess = true,
                Comment = "IsSuccess",
                JWT = jwt.Item1,
                JWTValidtTo = jwt.Item2,
                RefreshToken = user.Refresh,
                RefreshTokenValidTo = user.DeactivationDate,
            };
        }

        public async Task<UserRefreshResponseDTO> RefreshJWTAsync
            (
                UserRefreshRequestDTO request,
                string jwt,
                CancellationToken cancellation
            ) 
        {         
            if (string.IsNullOrEmpty(jwt)) 
            {
                return new UserRefreshResponseDTO
                {
                    IsSuccess = false,
                    Comment = "JWT is null",
                };
            }

            if (!_authenticationRepository.IsJWTGeneratedByThisServer(jwt))
            {
                return new UserRefreshResponseDTO
                {
                    IsSuccess = false,
                    Comment = "JWT is not valid",
                };
            }
            var claims = _authenticationRepository.GetClaimsFromJWT(jwt);
            var name = _authenticationRepository.GetNameFromClaims(claims);

            if (string.IsNullOrEmpty(name)) 
            {
                return new UserRefreshResponseDTO 
                { 
                   IsSuccess = false,
                   Comment = "Name is Null",
                };
            }

            var isParsedName = Guid.TryParse(name, out var userId);
            if (!isParsedName) 
            {
                return new UserRefreshResponseDTO 
                {
                    IsSuccess = false,
                    Comment = "Name Hasn`t Parsing",
                };
            }

            var user = await _dbContext.Users.Where(x => x.Id == userId).FirstOrDefaultAsync(cancellation);
            if (user == null || user.Refresh != request.RefreshToken) 
            {
                return new UserRefreshResponseDTO 
                { 
                    IsSuccess = false,
                    Comment = "User No Exist",
                };
            }

            var newJWT = _authenticationRepository.GenerateJWTStringAndDateTimeValidTo
                (user.Id.ToString(), new List<string>() { "user" });

            return new UserRefreshResponseDTO
            { 
                IsSuccess = true, 
                Comment = "Success",
                JWT = newJWT.Item1,
                JWTValidtTo = newJWT.Item2,
                RefreshToken = user.Refresh,
                RefreshTokenValidTo = user.DeactivationDate,
            };
        }

        public async Task<bool> LogOutAsync
            (
                IEnumerable<Claim> claims,
                CancellationToken cancellation
            ) 
        {
            var name = _authenticationRepository.GetNameFromClaims(claims);
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            var isParsedName = Guid.TryParse(name, out var userId);
            if (!isParsedName)
            {
                return false;
            }

            var user = await _dbContext.Users.Where(x => x.Id == userId).FirstOrDefaultAsync(cancellation);
            if (user == null) 
            {
                return false;
            }

            user.Refresh = null;
            user.DeactivationDate = null;
            await _dbContext.SaveChangesAsync(cancellation);

            return true;
        }         
    }
}
