using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Core.Models;
using System.Linq.Expressions;

namespace MVC_Core.IServices
{
    public interface ISchoolService
    {
        Task<IEnumerable<School>> GetAll();
        Task<IEnumerable<School>> GetPage(int pageIndex, int pageSize);
        Task<School> GetById(int id);
        Task<School> Find(Expression<Func<School, bool>> predicate);
        Task<bool> Add(School entity);
        Task<bool> Update(School entity);
        Task<bool> Delete(School entity);
        Task<int> Count();
        Task<IEnumerable<SelectListItem>> GetListItems();
    }
}
