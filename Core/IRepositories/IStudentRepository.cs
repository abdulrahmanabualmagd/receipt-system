using Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.IRepositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<SelectListItem>> GetListItems();
    }
}
