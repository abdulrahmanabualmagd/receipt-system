using Core.Entities.Application;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PaymentController : Controller
    {
        #region Dependency Injection
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        #endregion

        public async Task<IActionResult> Index()
            => View(await _paymentService.UserGetAllAsync(User));
    }
}
