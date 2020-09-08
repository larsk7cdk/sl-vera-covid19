using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace sl_vera_covid19.mvc.Persistance.Core
{
    public class CosmosDbService<T> : ICosmosDbService<T>
    {
        private readonly Container _container;

        public CosmosDbService(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }


        public async Task<T> GetItemAsync(string id)
        {
            try
            {
                var response = await this._container.ReadItemAsync<T>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default;
            }

        }

        public async Task<IEnumerable<T>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
            var results = new List<T>();
            
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task AddItemAsync(string id, T item) =>
            await _container.CreateItemAsync(item, new PartitionKey(id));

        public async Task UpdateItemAsync(string id, T item) =>
            await _container.UpsertItemAsync(item, new PartitionKey(id));

        public async Task DeleteItemAsync(string id) =>
        await _container.DeleteItemAsync<T>(id, new PartitionKey(id));
    }
}