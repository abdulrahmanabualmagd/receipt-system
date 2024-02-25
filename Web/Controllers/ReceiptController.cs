using Core.DTOs;
using Core.Entities.Application;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ReceiptController : Controller
    {
        #region Dependency Injection
        private readonly IReceiptService _receiptService;

        public ReceiptController(IReceiptService baseService)
        {
            _receiptService = baseService;
        }
        #endregion

        #region Get All Receipts
        public async Task<IActionResult> Index()
        {
            return View(await _receiptService.UserGetAllAsync(User));

        }
        #endregion

        #region Get User Receipt by Id
        public async Task<IActionResult> Receipt(int id)
        {
            return View(await _receiptService.UserGetByIdAsync(User, id));
        }
        #endregion

        #region Create New Receipt
        public async Task<IActionResult> NewReceipt()
        {
            return View((await _receiptService.GetUserOpenReceiptAsync(User)).Items.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> NewReceipt(List<Item> items)
        {

            var check = await _receiptService.CreateReceiptAsync(User, items);

            if(!check)
            {
                TempData["Message"] = "Please don't exceed the limits of the Stock";
                return RedirectToAction("NewReceipt");
            }

            TempData["Message"] = "Receipt Created Successfully!";
            return RedirectToAction("Index");
        }

        #endregion
    }
}
