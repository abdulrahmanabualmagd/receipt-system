using Microsoft.AspNetCore.Mvc;
using MVC_Core.Data;
using MVC_Core.Models;

namespace MVC_Core.Controllers
{
    public class StudentController : Controller
    {
        #region Dependency Injection
        private ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        public IActionResult GetAll()
        {
            IEnumerable<Student> students = _context.students.ToList();

            return View(students);
        }

    }
}
