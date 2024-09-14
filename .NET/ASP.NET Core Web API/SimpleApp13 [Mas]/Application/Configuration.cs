using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Configuration
    {
        public static IServiceCollection ApplicationConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUseCasesRepository, UseCasesRepository>();


            return serviceCollection;
        }
    }
}
