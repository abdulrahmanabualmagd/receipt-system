using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Core.Data;
using MVC_Core.IRepositories;
using MVC_Core.Models;
using MVC_Core.ViewModels;

namespace MVC_Core.Controllers
{
    public class StudentController : Controller
    {
        #region Repository Injection
            private readonly IRepository<Student> _studentRepository;
            private readonly IRepository<School> _schoolRepository;
            public StudentController(IRepository<Student> studentRepository, IRepository<School> schoolRepository)
            {
                _studentRepository = studentRepository;
                _schoolRepository = schoolRepository;
            }
        #endregion

        #region Student Get All
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Student> StudentList = await _studentRepository.GetAll();

            return View(StudentList);
        } 
        #endregion

        #region Student Details
        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentRepository.GetById(id);

            return View(student);
        }
        #endregion

        #region Student Edit
        // Get by Default
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentRepository.GetById(id);

            IEnumerable<SelectListItem> schools = await _schoolRepository.GetListItems();

            ViewData["Items"] = schools;

            return View(student);
        }

        // Post Http
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            bool check = await _studentRepository.Update(student);
            if (check)
            {
                return Redirect("/Home/Crud");
            }
            else
            {
            return BadRequest();
            }
        }
        #endregion

        #region Student Delete
        public async Task<IActionResult> Delete(int id)
        {
            Student student = await _studentRepository.GetById(id);
            bool check = await _studentRepository.Delete(student);

            return Redirect("/Home/Crud");
        }
        #endregion

        #region Student Add

        // Get Http
        public async Task<IActionResult> Add()
        {
            return View(new Student());
        }

        // Post Http
        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            bool check = await _studentRepository.Add(student);
            if (check)
            {
                return Redirect("/Home/Crud");
            }
            else
            {
                return Redirect("");
            }
        }
        #endregion
    }
}
