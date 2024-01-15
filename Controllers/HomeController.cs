/*
 * I'm using Generic repository also Unit of work (Repository Pattern)
 * I'm using two queries to get the count of students and schools, but I'm using two queries
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVC_Core.IRepositories;
using MVC_Core.Models;
using MVC_Core.ViewModels;

namespace MVC_Core.Controllers
{
    public class HomeController : Controller
    {
        #region Dependency Injection
        /*
         * Make sure you registered the dependency injection for the following repositories in the bulder.Services
         * To be able to use the Student Repository and School Repository
         */
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<School> _schoolRepository;

        public HomeController(IRepository<Student> studentRepository, IRepository<School> schoolRepository)
        {
            _studentRepository = studentRepository;
            _schoolRepository = schoolRepository;
        }
        #endregion

        #region Home Page
        public async Task<IActionResult> Home()
        {
            /*
             * If we are using an Asynchronous Programming 
             * we have to make the function async and use Generic Task as a return type
             * Next step we will get the data in just one query instead of using two separated queries
             * also how to hit the data only in case there are changes
             */

            #region Get School And Studnet Counts
            // We use await here to not freeze the Control while waiting for data 
            int StudentCount = await _studentRepository.Count();
            int SchoolCount = await _schoolRepository.Count();
            #endregion

            StudentSchoolCounter studentSchoolCounter = new StudentSchoolCounter(StudentCount, SchoolCount);

            return View(studentSchoolCounter);
        }
        #endregion

        #region GetDetails for Ajax Call
        public async Task<IActionResult> GetDetails()
        {
            #region Get Counts for Students and Schools
            int SchoolCount = await _schoolRepository.Count();
            int StudentCount = await _studentRepository.Count();
            #endregion

            return Json(new { schoolCount = SchoolCount, studentCount = StudentCount });
        }
        #endregion

        #region Crud For All Students
        public async Task<IActionResult> Crud(int page)
        {
            #region Null Exception
            if (page == null || page < 1)
            {
                page = 1;
            }
            #endregion

            IEnumerable<Student> students = await _studentRepository.GetPage(page, 5);
            ViewData["Page"] = page;
            return View(students);
        } 
        #endregion
    }
}
