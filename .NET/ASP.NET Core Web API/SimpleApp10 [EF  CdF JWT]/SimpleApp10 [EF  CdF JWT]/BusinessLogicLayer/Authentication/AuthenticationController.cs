using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp10__EF__CdF_JWT_.BusinessLogicLayer.Authentication.DTOs;
using SimpleApp10__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Repositories;
using System.Security.Claims;

namespace SimpleApp10__EF__CdF_JWT_.BusinessLogicLayer.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _repository;
        public AuthenticationController(IAuthenticationRepository repository) 
        { _repository = repository; }

        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationAsync
            (PersonRegistrationRequestDTO person, CancellationToken cancellation) 
        { 
            var result = await _repository.CreatePersonAsync(person, cancellation);            
            if (result.Item1 == true)return StatusCode(201); 
            return StatusCode(409,result.Item2); 
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync
            (PersonLoginRequestDTO person, CancellationToken cancellation) 
        { 
            var result = await _repository.LoginAsync(person, cancellation);
            if (result.IsSuccess == true) { return StatusCode(200, result.Value); }
            return StatusCode(401, result.Message); 
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshAsync
            ([FromBody] string refreshToken, CancellationToken cancellation) 
        { 
            var result = await _repository.GetJWTByRefreshTokenAsync(refreshToken, cancellation); 
            if (result.IsSuccess == true) return StatusCode(200, result.Value);
            return StatusCode(401, result.Message); 
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync(CancellationToken cancellation) 
        {
            var email = "";
            User.Claims.ToList();
            foreach (var claim in User.Claims) 
            { 
                if (claim.Type == ClaimTypes.Name) email = claim.Value;
            }
            var result = await _repository.LogoutAsync(email, cancellation);
            if (result.Item1 == true) return Ok(result.Item2);
            return StatusCode(404,result.Item2);
        }
    }
}
