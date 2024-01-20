using Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.IRepositories
{
    public interface ISchoolRepository : IRepository<School>
    {
        Task<IEnumerable<SelectListItem>> GetListItems();
    }
}
