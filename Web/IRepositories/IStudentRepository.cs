using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Core.Models;

namespace MVC_Core.IRepositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<SelectListItem>> GetListItems();
    }
}
