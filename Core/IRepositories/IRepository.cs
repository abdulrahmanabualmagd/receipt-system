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


namespace Core.IRepositories
{
    public interface IRepository<T> where T : class    // Classes Only Constraint
    {
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(string[]? include = null);
        Task<IEnumerable<T>> GetPageAsync(int pageIndex, int pageSize, string[]? include = null);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate, string[]? include = null);
        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate, string[]? include = null);
        Task<int> CountAsync();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        void Attach(T entity);
        void Detach(T entity);
        Task<IEnumerable<SelectListItem>> GetListItems(Expression<Func<T, SelectListItem>> predicate);
    }
}
