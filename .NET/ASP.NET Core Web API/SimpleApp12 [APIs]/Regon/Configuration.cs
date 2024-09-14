using Microsoft.Extensions.DependencyInjection;
using Regon.Repositories;
using Regon.Repositories.EnvelopesDeserialization;
using Regon.Repositories.Requests;
using Regon.Repositories.SoapEnvelopes;

namespace Regon
{
    public static class Configuration
    {
        public static IServiceCollection RegonConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEnvelopesRepository, EnvelopesRepository>();
            serviceCollection.AddTransient<IRegonRepository, RegonRepository>();
            serviceCollection.AddTransient<
                IDeserializationRepository,
                DeserializationRepository>();
            serviceCollection.AddTransient<IRequestsRepository, RequestsRepository>();

            return serviceCollection;
        }
    }
}
