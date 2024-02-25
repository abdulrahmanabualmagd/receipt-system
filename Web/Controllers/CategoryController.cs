using Core.Entities.Application;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        #region Depdendency Injection
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #endregion

        #region Get All
        public async Task<IActionResult> Index()
            => View(await _categoryService.GetAllAsync()); 
        #endregion
    }
}
