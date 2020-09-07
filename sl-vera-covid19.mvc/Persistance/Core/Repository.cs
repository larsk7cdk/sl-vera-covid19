using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sl_vera_covid19.mvc.Persistance.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Task<IList<T>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> FindAsync(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
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