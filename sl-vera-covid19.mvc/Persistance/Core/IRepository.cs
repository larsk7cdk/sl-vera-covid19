using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sl_vera_covid19.mvc.Persistance.Core
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> FindAllAsync();
        Task<IList<T>> FindAsync(Func<T, bool> predicate);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}