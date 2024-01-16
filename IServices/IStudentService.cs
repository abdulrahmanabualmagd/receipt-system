using MVC_Core.IRepositories;
using MVC_Core.Models;
using System.Linq.Expressions;

namespace MVC_Core.IServices
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAll();
        Task<IEnumerable<Student>> GetPage(int pageIndex, int pageSize);
        Task<Student> GetById(int id);
        Task<Student> Find(Expression<Func<Student, bool>> match);
        Task<bool> Add(Student entity);
        Task<bool> Update(Student entity);
        Task<bool> Delete(Student entity);
        Task<int> Count();
    }
}
