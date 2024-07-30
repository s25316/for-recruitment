using SimpleApp11__EF__CdF_JWT_.Middlewares.CustomMiddlewares;

namespace SimpleApp11__EF__CdF_JWT_.Middlewares
{
    public static class CustomMiddlewaresAdapter
    {
        public static IApplicationBuilder UseAuthenticationWerifier(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationWerifierMiddleware>();
        }
    }
}
