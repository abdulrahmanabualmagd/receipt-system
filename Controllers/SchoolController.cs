using Microsoft.AspNetCore.Mvc;
using MVC_Core.Models;
using MVC_Core.Repositories;

namespace MVC_Core.Controllers
{
    public class SchoolController : Controller
    {
        #region Repository Injection
        private readonly IRepository<School> _schoolRepository;

        public SchoolController(IRepository<School> schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        #endregion

        #region Get All
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<School> SchooolList = await _schoolRepository.GetAll();
            return View(SchooolList);
        } 
        #endregion

    }
}
