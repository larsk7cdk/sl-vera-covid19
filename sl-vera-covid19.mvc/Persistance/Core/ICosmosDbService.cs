using System.Collections.Generic;
using System.Threading.Tasks;

namespace sl_vera_covid19.mvc.Persistance.Core
{
    public interface ICosmosDbService<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(string query);
        Task<T> GetItemAsync(string id);
        Task AddItemAsync(string id, T item);
        Task UpdateItemAsync(string id, T item);
        Task DeleteItemAsync(string id);
    }
}