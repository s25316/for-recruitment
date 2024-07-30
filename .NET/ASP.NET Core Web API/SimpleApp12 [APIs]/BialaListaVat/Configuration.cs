using BialaListaVat.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BialaListaVat
{
    public static class Configuration
    {
        public static IServiceCollection BialaListaVatConfiguration(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddTransient<IWhiteListVatRepository, WhiteListVatRepository>();

            return serviceCollection;
        }
    }
}
