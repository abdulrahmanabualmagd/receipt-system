using Microsoft.AspNetCore.Mvc;
using MVC_Core.Models;
using MVC_Core.Repositories;

namespace MVC_Core.Controllers
{
    public class SchoolController : Controller
    {
        #region Repository Injection
        private readonly IRepository<School> _repository;

        public SchoolController(IRepository<School> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Get All
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<School> SchooolList = await _repository.GetAll(["Students"]);
            return View(SchooolList);
        } 
        #endregion

    }
}
