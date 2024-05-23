using Microsoft.EntityFrameworkCore;
using SimpleApp10__EF__CdF_JWT_.DatabaseLayer;
using SimpleApp10__EF__CdF_JWT_.DatabaseLayer.Configurations;
using System.Security.Claims;

namespace SimpleApp10__EF__CdF_JWT_.Middlewares.CustomMiddlewares
{
    public class AuthenticationWerifierMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthenticationWerifierMiddleware
            (RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, LibraryDBContext libraryDB)
        {
            if (context.Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                var token = authorizationHeader.ToString().Replace("Bearer ", "");
                //Console.WriteLine($"JWT Token: {token}");
                var claims = context.User.Claims.ToList();
                foreach (var claim in claims)
                {
                    if (claim.Type == ClaimTypes.Name)
                    {
                        var email = claim.Value;
                        //Console.WriteLine(email);
                        var person = await libraryDB.People.Where(p => p.Email == email)
                            .FirstOrDefaultAsync();
                        if (person == null || person.JWT == null || person.JWT != token)
                        {
                            context.Response.StatusCode = 401;
                            return;
                        }
                    }
                }
            }
            await _next(context);
        }
    }
}
