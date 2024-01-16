using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MVC_Core.Data;
using MVC_Core.Models;
using MVC_Core.Repositories;
using MVC_Core.UoW;
using MVC_Core.ViewModels;

namespace MVC_Core.Controllers
{
    public class StudentController : Controller
    {
        #region Repository Injection

        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Student Get All
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Student> StudentList = await _unitOfWork.Students.GetAll(["School"]);

            return View(StudentList);
        } 
        public async Task<IActionResult> GetPage(int page)
        {
            #region Null Exception
            if (page == null || page < 1)
            {
                page = 1;
            }
            #endregion

            IEnumerable<Student> StudentList = await _unitOfWork.Students.GetPage(page, 5, ["School"]);

            return View("GetAll", StudentList);
        } 
        #endregion

        #region Student Details
        public async Task<IActionResult> Details(int id)
        {
            var student = await _unitOfWork.Students.Find(s => s.Id == id, ["School"]);

            return View(student);
        }
        #endregion

        #region Student Edit
        // Get by Default
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _unitOfWork.Students.Find(s=> s.Id == id, ["School"]);

            ViewData["Items"] = await _unitOfWork.Schools.GetListItems();

            return View(student);
        }

        // Post Http
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            bool check = await _unitOfWork.Students.Update(student);
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
            Student student = await _unitOfWork.Students.GetById(id);
            bool check = await _unitOfWork.Students.Delete(student);

            if (check)
            {
                TempData["Message"] = $"Student {student.Name} Deleted Successfully!";
            }
            return Redirect("/Home/Crud");
        }
        #endregion

        #region Student Add
        // Get Http
        public async Task<IActionResult> Add()
        {
            ViewData["Items"] = await _unitOfWork.Schools.GetListItems();

            return View(new Student());
        }

        // Post Http
        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            bool check = await _unitOfWork.Students.Add(student);
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
