using BialaListaVat.Repositories;
using BialaListaVat.Repositories.Deserialization;
using BialaListaVat.Repositories.Url;
using Microsoft.Extensions.DependencyInjection;

namespace BialaListaVat
{
    public static class Configuration
    {
        public static IServiceCollection BialaListaVatConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IWhiteListVatRepository, WhiteListVatRepository>();
            serviceCollection.AddTransient<IUrlRepository, UrlRepository>();
            serviceCollection.AddTransient<IDeserializationRepository, DeserializationRepository>();

            return serviceCollection;
        }
    }
}
