using Microsoft.AspNetCore.Mvc;
using MVC_Core.IServices;
using MVC_Core.Models;
using MVC_Core.Repositories;
using MVC_Core.UoW;

namespace MVC_Core.Controllers
{
    public class SchoolController : Controller
    {
        #region Repository Injection
        private readonly ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        #endregion

        public async Task<IActionResult> GetAll()
            => View(await _schoolService.GetAll());
        

    }
}
