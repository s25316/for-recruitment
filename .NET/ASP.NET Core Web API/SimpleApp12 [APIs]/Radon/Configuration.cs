using Microsoft.Extensions.DependencyInjection;
using Radon.Repositories;

namespace Radon
{
    public static class Configuration
    {
        public static IServiceCollection RadonConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUniversitiesRepository, UniversitiesRepository>();

            return serviceCollection;
        }
    }
}
