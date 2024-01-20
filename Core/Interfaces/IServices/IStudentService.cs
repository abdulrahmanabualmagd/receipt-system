using Infrastructure.Models;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Core.Interfaces.IServices
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAll();
        Task<IEnumerable<Student>> GetPage(int pageIndex, int pageSize);
        Task<Student> GetById(int id);
        Task<Student> Find(Expression<Func<Student, bool>> predicate);
        Task<bool> Add(Student entity);
        Task<bool> Update(Student entity);
        Task<bool> Delete(Student entity);
        Task<int> Count();
        Task<IEnumerable<SelectListItem>> GetListItems();
    }
}
