using Microsoft.EntityFrameworkCore;
using SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Repositories;
using SimpleApp11__EF__CdF_JWT_.DataAccessLayer;

namespace SimpleApp11__EF__CdF_JWT_.Middlewares.CustomMiddlewares
{
    public class AuthenticationWerifierMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationWerifierMiddleware (RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke 
            (
            HttpContext context, 
            PortalDBContext dBContext,
            IAuthenticationRepository authenticationRepository,
            IConfiguration configuration
            ) 
        {
            if (context.Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                var jwt = authorizationHeader.ToString().Replace("Bearer ", "");


                var isValidJWT = authenticationRepository.IsJWTGeneratedByThisServer(jwt);

                if (!isValidJWT)
                {
                    context.Response.StatusCode = 401;
                    return;
                }

                var claims = authenticationRepository.GetClaimsFromJWT(jwt);
                var name = authenticationRepository.GetNameFromClaims(claims);
                
                if (string.IsNullOrEmpty(name)) 
                {
                    context.Response.StatusCode = 401;
                    return;
                }

                var isParsedToGuid = Guid.TryParse(name, out var id);
                if (!isParsedToGuid) 
                {
                    context.Response.StatusCode = 401;
                    return;
                }

                var user = await dBContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (user == null || string.IsNullOrEmpty(user.Refresh)) 
                {
                    context.Response.StatusCode = 401;
                    return;
                }
            }
            await _next(context);
        }
    }
}
