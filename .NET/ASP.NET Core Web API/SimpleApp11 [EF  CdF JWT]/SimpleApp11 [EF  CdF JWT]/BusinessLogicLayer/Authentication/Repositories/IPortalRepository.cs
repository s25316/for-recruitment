using SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Models;
using System.Security.Claims;

namespace SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Repositories
{
    public interface IPortalRepository
    {
        Task<UserCreateResponseDTO> UserCreateAsync
            (
            UserCreateRequestDTO userDTO,
            CancellationToken cancellation
            );

        Task<UserLoginResponseDTO> LoginInAsync(
            UserLoginRequestDTO request,
            CancellationToken cancellation
            );
        Task<UserRefreshResponseDTO> RefreshJWTAsync
            (
                UserRefreshRequestDTO request,
                string jwt,
                CancellationToken cancellation
            );
        Task<bool> LogOutAsync
           (
               IEnumerable<Claim> claims,
               CancellationToken cancellation
           );
    }
}
