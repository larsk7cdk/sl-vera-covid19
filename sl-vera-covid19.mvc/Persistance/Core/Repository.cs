using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace sl_vera_covid19.mvc.Persistance.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private Container _container;

        public Repository(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            this._container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public Task<IList<T>> FindAllAsync()
        {
            
        }

        public Task<IList<T>> FindAsync(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync( T entity)
        {
            await this._container.CreateItemAsync<T>(entity, new PartitionKey(entit))
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}