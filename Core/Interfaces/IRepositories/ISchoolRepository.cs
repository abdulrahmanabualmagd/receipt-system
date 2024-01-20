using Infrastructure.Models;
using System.Web.Mvc;

namespace Core.Interfaces.IRepositories
{
    public interface ISchoolRepository : IRepository<School>
    {
        Task<IEnumerable<SelectListItem>> GetListItems();
    }
}
