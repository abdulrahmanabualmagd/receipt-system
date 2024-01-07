using Microsoft.AspNetCore.Mvc;
using MVC_Core.IRepositories;
using MVC_Core.Models;

namespace MVC_Core.Controllers
{
    public class HomeController : Controller
    {
        #region Dependency Injection
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<School> _schoolRepository;

        public HomeController(IRepository<Student> studentRepository, IRepository<School> schoolRepository)
        {
            _studentRepository = studentRepository;
            _schoolRepository = schoolRepository;
        } 
        #endregion

        public IActionResult Home()
        {
            
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
