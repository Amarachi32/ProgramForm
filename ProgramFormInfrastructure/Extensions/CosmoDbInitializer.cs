using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using ProgramFormCore.Models;


namespace ProgramFormInfrastructure.Extensions
{
    public class CosmosDbInitializer
    {
        private readonly IConfiguration _configuration;
        private readonly CosmosClient _cosmosClient;

        public CosmosDbInitializer(IConfiguration configuration)
        {
            _configuration = configuration;
            _cosmosClient = new CosmosClient(
                _configuration["CosmosDBConfig:AccountUri"],
                _configuration["CosmosDBConfig:AccountPrimaryKey"]
            );
        }

        public async Task<Container> InitializeContainerAsync<T>() where T : BaseEntity
        {
            var databaseName = _configuration["CosmosDBConfig:DatabaseName"];
            var containerName = typeof(T).Name;

            var database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);
            var container = await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

            return container;
        }
    }


}
