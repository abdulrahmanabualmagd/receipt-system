using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.SchoolServcie
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
