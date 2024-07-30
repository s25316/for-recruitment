using Microsoft.Extensions.DependencyInjection;
using Regon.Repositories;
using Regon.Repositories.SoapEnvelopes;

namespace Regon
{
    public static class Configuration
    {
        public static IServiceCollection RegonConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRegonEnvelopesRepository, RegonEnvelopesRepository>();
            serviceCollection.AddTransient<IRegonRepository, RegonRepository>();

            return serviceCollection;
        }
    }
}
