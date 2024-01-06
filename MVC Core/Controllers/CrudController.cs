using Microsoft.AspNetCore.Mvc;
using MVC_Core.Data;

namespace MVC_Core.Controllers
{
    public class CrudController : Controller
    {
        #region Dependency Injection
        private ApplicationDbContext _cotnext;
        public CrudController(ApplicationDbContext context)
        {
            _cotnext = context;
        }
        #endregion


        #region Students & Schools
        public IActionResult GetAllStudents()
        {
            var q = _cotnext.students.ToList();
            return View(q);
        }


        public IActionResult GetAllSchools()
        {
            var q = _cotnext.Schools.ToList();
            return View(q);
        } 
        #endregion



    }
}
