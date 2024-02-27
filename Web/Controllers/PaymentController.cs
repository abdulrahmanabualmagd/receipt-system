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

        #region Get All
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pagination = new PaginationDto();
            ViewBag.Page = pagination.Page;
            ViewBag.TotalPages = await _paymentService.UserGetTotalPagesAsync(User, pagination.Size);
            return View(await _paymentService.UserGetPagesAsync(User, pagination));
        }

        [HttpPost]
        public async Task<IActionResult> Index(PaginationDto pagination)
        {
            ViewBag.Page = pagination.Page;
            ViewBag.TotalPages = await _paymentService.UserGetTotalPagesAsync(User, pagination.Size);
            return View(await _paymentService.UserGetPagesAsync(User, pagination));
        }
        #endregion
        
        #region CustomerPayment

        [HttpPost]
        public async Task<IActionResult> Receipt(int receiptId)
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
