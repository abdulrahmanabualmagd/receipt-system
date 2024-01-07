using Microsoft.AspNetCore.Mvc;
using MVC_Core.Data;
using MVC_Core.IRepositories;
using MVC_Core.Models;

namespace MVC_Core.Controllers
{
    public class StudentController : Controller
    {
            #region Repository Injection
            private readonly IRepository<Student> _studentRepository;

            public StudentController(IRepository<Student> studentRepository)
            {
                _studentRepository = studentRepository;
            }
            #endregion

        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Student> StudentList = await _studentRepository.GetAll();

            return View(StudentList);
        }
    }
}
