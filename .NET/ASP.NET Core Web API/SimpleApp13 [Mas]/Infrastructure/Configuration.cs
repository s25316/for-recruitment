using Application.Database;
using Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection InfrastructureConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<BankDbContext, BankMsSqlDbContext>();

            return serviceCollection;
        }
    }
}
