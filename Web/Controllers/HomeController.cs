using Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        #region Dependency Injection
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService) 
        {
            _homeService = homeService;
        }
        #endregion

        public  async Task<IActionResult> Index()
            => View( await _homeService.GetCountsAsync());
    }
}
