/*
 * - Generic Repository Interface:
 *      - This interface defines a standard set of methods for generic CRUD operations, promoting 
 *      - abstraction and separation of concerns in data access. It serves as a modular foundation, 
 *      - allowing easy creation of concrete repositories for various entity types. The repository 
 *      - pattern enhances code maintainability, flexibility, and testability by encapsulating data 
 *      - access logic and providing a consistent interface across the application.
 *      
 *      We are using bool return as a feedback to know if the operation is completed successfully or not
 */
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace MVC_Core.Repositories
{
    public interface IRepository<T> where T  : class    // Classes Only Constraint
    {
        Task<IEnumerable<T>> GetAll(string[]? include = null);
        Task<IEnumerable<T>> GetPage(int pageIndex, int pageSize, string[]? include = null);

        Task<T> GetById(int id);
        Task<T> Find(Expression<Func<T, bool>> match, string[]? include = null);

        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);

        Task<int> Count();

        Task<IEnumerable<SelectListItem>> GetListItems(Expression<Func<T, SelectListItem>> match, string[]? include = null);
    }
}
