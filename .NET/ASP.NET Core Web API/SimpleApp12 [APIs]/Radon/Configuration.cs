using Microsoft.Extensions.DependencyInjection;
using Radon.Repositories;
using Radon.Repositories.Deserialization;
using Radon.Repositories.Url;

namespace Radon
{
    public static class Configuration
    {
        public static IServiceCollection RadonConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUniversitiesRepository, UniversitiesRepository>();
            serviceCollection.AddTransient<IDeserializationRepository, DeserializationRepository>();
            serviceCollection.AddTransient<IUrlRepository, UrlRepository>();

            return serviceCollection;
        }
    }
}
