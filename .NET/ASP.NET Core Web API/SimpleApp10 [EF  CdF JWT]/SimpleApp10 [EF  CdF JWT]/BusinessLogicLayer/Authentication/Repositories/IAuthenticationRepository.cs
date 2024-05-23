using SimpleApp10__EF__CdF_JWT_.BusinessLogicLayer.Authentication.DTOs;
using System.Threading.Tasks;

namespace SimpleApp10__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<ResponseDTO<JWTResponseDTO>> LoginAsync
            (PersonLoginRequestDTO person, CancellationToken cancellation);

        Task<Tuple<bool, string>> CreatePersonAsync
            (PersonRegistrationRequestDTO person, CancellationToken cancellation);

        Task<ResponseDTO<JWTResponseDTO>> GetJWTByRefreshTokenAsync
            (string refresh, CancellationToken cancellation);

        Task<Tuple<bool, string>> LogoutAsync(string email, CancellationToken cancellation);
    }
}
