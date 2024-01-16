using Microsoft.AspNetCore.Mvc;
using MVC_Core.Models;
using MVC_Core.Repositories;
using MVC_Core.UoW;

namespace MVC_Core.Controllers
{
    public class SchoolController : Controller
    {
        #region Repository Injection
        private readonly IUnitOfWork _unitOfWork;
        public SchoolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Get All
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<School> SchooolList = await _unitOfWork.Schools.GetAll(["Students"]);
            return View(SchooolList);
        } 
        #endregion

    }
}
