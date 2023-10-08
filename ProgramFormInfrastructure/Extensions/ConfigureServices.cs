using Microsoft.Extensions.DependencyInjection;
using ProgramFormCore.Implementations;
using ProgramFormCore.Interfaces;
using ProgramFormCore.Models;
using ProgramFormInfrastructure.Interfaces;
using ProgramFormInfrastructure.Services;

namespace ProgramFormInfrastructure.Extensions
{
    public static class ConfigureServices
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddSingleton<CosmosDbInitializer>();

            services.AddSingleton(provider =>
            {
                var cosmosDbInitializer = provider.GetRequiredService<CosmosDbInitializer>();
                return cosmosDbInitializer.InitializeContainerAsync<ProgramDetails>().Result;
            });

            services.AddScoped<IRepository<ProgramDetails>, Repository<ProgramDetails>>();
            services.AddScoped<IProgramDetailsService, ProgramDetailsService>();
        }

    }
}
