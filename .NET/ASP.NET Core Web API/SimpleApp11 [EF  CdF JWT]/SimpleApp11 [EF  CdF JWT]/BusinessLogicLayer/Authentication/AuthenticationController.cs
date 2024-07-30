using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Models;
using SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Repositories;
using System.Security.Claims;

namespace SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IPortalRepository _portalRepository;

        public AuthenticationController(IPortalRepository portalRepository) 
        { 
            _portalRepository = portalRepository; 
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> UserCreateAsync(
            UserCreateRequestDTO request,
            CancellationToken cancellation
            ) 
        {
            var result = await _portalRepository.UserCreateAsync(request, cancellation);
            return (result.IsSuccess)? StatusCode(201) : StatusCode(406, result.Message);
        }

        [AllowAnonymous]
        [HttpPost("LoginIn")]
        public async Task<IActionResult> LoginInAsync(
            UserLoginRequestDTO request,
            CancellationToken cancellation
            )
        { 
            var result = await _portalRepository.LoginInAsync(request, cancellation);
            return (result.IsSuccess)? Ok(result) : StatusCode(401);
        }

        [AllowAnonymous]
        [HttpPost("Refresh")]
        public async Task<IActionResult> RefreshAsync
            (
            UserRefreshRequestDTO request, 
            CancellationToken cancellation
            ) 
        {
            var isExistAuthorizationHeader = Request.Headers.TryGetValue("Authorization", out var authorizationHeader);
            if (!isExistAuthorizationHeader)
            {
                return StatusCode(401);
            }
            var jwt = authorizationHeader.ToString().Replace("Bearer ", "");

            var result = await _portalRepository.RefreshJWTAsync(request, jwt, cancellation);

            return (result.IsSuccess)? Ok(result) : StatusCode(401);
        }

        [Authorize]
        [HttpGet]
        public IActionResult aaa() 
        {
            var x = new { 
                zz = DateTime.Now, 
                bb = DateTime.Now.ToLocalTime() 
            };

            return Ok(x);
        }


        [Authorize]
        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOutasync(CancellationToken cancellation) 
        {
            var claims = User.Claims.ToList();
            var result = await _portalRepository.LogOutAsync(claims, cancellation);
            return (result) ? Ok(result) : StatusCode(400);
        }

    }
}
