using Microsoft.Extensions.DependencyInjection;
using ProgramFormCore.Models;


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

        }

    }
}
