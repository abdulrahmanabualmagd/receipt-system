using Microsoft.AspNetCore.Mvc;
using Core.SchoolServcie;

namespace Web.Controllers
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
