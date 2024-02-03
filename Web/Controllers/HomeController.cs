using Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        #region Dependency Injection
        private readonly ICountsSerivce _countsService;

        public HomeController(ICountsSerivce countsSerivce)
        {
            _countsService = countsSerivce;
        }
        #endregion

        public async Task<IActionResult> Home()
            => View(await _countsService.GetCountsAsync());
        
        public async Task<IActionResult> GetDetails()
            => Json( await _countsService.GetCountsAsync());
    }
}
