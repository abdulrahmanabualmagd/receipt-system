using System.Web.Mvc;
using Infrastructure.Models;

namespace Core.Interfaces.IRepositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<SelectListItem>> GetListItems();
    }
}
