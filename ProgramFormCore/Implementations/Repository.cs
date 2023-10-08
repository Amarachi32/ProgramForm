using ProgramFormCore.Interfaces;
using ProgramFormCore.Models;
using Microsoft.Azure.Cosmos;
namespace ProgramFormCore.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Container _container;

        public Repository(Container container)
        {
            _container = container;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _container.CreateItemAsync(entity, new PartitionKey(entity.Id));
            return entity;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            try
            {
                ItemResponse<T> response = await _container.ReadItemAsync<T>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = _container.GetItemQueryIterator<T>();
            var results = new List<T>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<T> UpdateAsync(string id, T entity)
        {
            await _container.ReplaceItemAsync(entity, id, new PartitionKey(id));
            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<T>(id, new PartitionKey(id));
        }
    }
}
