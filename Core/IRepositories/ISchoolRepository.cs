using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Core.Models;

namespace MVC_Core.IRepositories
{
    public interface ISchoolRepository : IRepository<School>
    {
        Task<IEnumerable<SelectListItem>> GetListItems();
    }
}
