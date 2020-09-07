using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sl_vera_covid19.mvc.Persistance.Core
{
    public interface IBaseRepositoryFacade<in TIn, TOut>

    {
        Task<IEnumerable<TOut>> FindAllAsync();
        Task<IEnumerable<TOut>> FindByIdAsync(int id);
        Task<IActionResult> CreateAsync(TIn entity);
        Task<IActionResult> UpdateAsync(TIn entity);
        Task<IActionResult> DeleteAsync(int id);
    }
}