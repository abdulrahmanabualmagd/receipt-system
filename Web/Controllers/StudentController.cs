using Microsoft.AspNetCore.Mvc;
using MVC_Core.IServices;
using MVC_Core.Models;

namespace MVC_Core.Controllers
{
    public class StudentController : Controller
    {
        #region Repository Injection

        private readonly IStudentService _studentService;
        private readonly ISchoolService _schoolService;
        public StudentController(IStudentService studentService, ISchoolService schoolService)
        {
            _studentService = studentService;
            _schoolService = schoolService;
        }
        #endregion

        #region Student Get All
        public async Task<IActionResult> GetAll()
        {
            return View(await _studentService.GetAll());
        } 
        public async Task<IActionResult> GetPage(int page = 1)
        {
            return View("GetAll", await _studentService.GetPage(page, 5));
        } 
        #endregion

        #region Student Details
        public async Task<IActionResult> Details(int id)
        {
            return View(await _studentService.Find(s => s.Id == id));
        }
        #endregion

        #region Student Edit
        // Get by Default
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            ViewData["Items"] = await _schoolService.GetListItems();

            return View(await _studentService.Find(s => s.Id == id));
        }

        // Post Http
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            bool check = await _studentService.Update(student);
            if (check)
            {
                TempData["Message"] = $"Student {student.Name} Have beed Modified Successfully!";

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
            Student student = await _studentService.GetById(id);
            bool check = await _studentService.Delete(student);

            if (check)
            {
                TempData["Message"] = $"Student {student.Name} Deleted Successfully!";
            }
            else
            {
                TempData["Message"] = $"Unable to Delete Student {student.Name}!";
            }
            return Redirect("/Home/Crud");
        }
        #endregion

        #region Student Add
        // Get Http
        public async Task<IActionResult> Add()
        {
            ViewData["Items"] = await _studentService.GetListItems();
            return View(new Student());
        }

        // Post Http
        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool check = await _studentService.Add(student);

            if (check)
            {
                TempData["Message"] = $"Student {student.Name} Added Successfully!";
                return Redirect("/Home/Crud");
            }
            else
            {
                TempData["Message"] = "Couldn't Add Student Successfully!";
                return Redirect("");
            }
        }
        #endregion
    }
}
