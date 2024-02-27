using Core.IServices;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;

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

        #region CustomerPayment
        public async Task<IActionResult> Index()
        {
            return View(await _paymentService.UserGetAllAsync(User));
        }

        [HttpPost]
        public async Task<IActionResult> Index(int receiptId)
        {
            return View(await _paymentService.UserGetByIdAsync(User, receiptId));
        } 
        #endregion

        #region PayReceipt
        public async Task<IActionResult> PayReceipt(PaymentCredentialsDto paymentCredentials)
        {
            var result = await _paymentService.UserAddAsync(User, paymentCredentials);

            if (result.IsValid)
                TempData["Message"] = result.Message;
            else
                TempData["Message"] = "Payment Failed!";

            return RedirectToAction("Index", "Receipt");
        } 
        #endregion
    }
}
