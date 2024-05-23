using SimpleApp10__EF__CdF_JWT_.Middlewares.CustomMiddlewares;
using System.Runtime.CompilerServices;

namespace SimpleApp10__EF__CdF_JWT_.Middlewares
{
    public static class CustomMiddlewaresAdapter
    {
        public static IApplicationBuilder UseAuthenticationWerifier(this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<AuthenticationWerifierMiddleware>();
        }
    }
}
