/*
 * I'm using Generic repository also Unit of work (Repository Pattern)
 * I'm using two queries to get the count of students and schools, but I'm using two queries
 * 
 * If we are using an Asynchronous Programming 
 * we have to make the function async and use Generic Task as a return type
 * Next step we will get the data in just one query instead of using two separated queries
 * also how to hit the data only in case there are changes
 *
 * Make sure you registered the dependency injection for the following repositories in the bulder.Services
 * To be able to use the Student Repository and School Repository
 */
using Microsoft.AspNetCore.Mvc;
using MVC_Core.IServices;
using MVC_Core.Models;
using MVC_Core.ViewModels;

namespace MVC_Core.Controllers
{
    public class HomeController : Controller
    {
        #region Dependency Injection
        private readonly IStudentService _studentService;
        private readonly ISchoolService _schoolService;

        public HomeController(IStudentService studentService, ISchoolService schoolService)
        {
            _studentService = studentService;
            _schoolService = schoolService;
        }
        #endregion

        public async Task<IActionResult> Home()
            => View(new StudentSchoolCounter (
                await _studentService.Count(), 
                await _schoolService.Count()
                ));
        
        public async Task<IActionResult> GetDetails()
            => Json(new { 
                schoolCount = await _schoolService.Count(), 
                studentCount = await _studentService.Count() 
            });
        
        public async Task<IActionResult> Crud(int page = 1)
        {
            ViewData["Page"] = page;
            return View(await _studentService.GetPage(page, 5));
        } 
    }
}
