using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using MVC_Core.DTOs;
using MVC_Core.Models;
using MVC_Core.Services;
using NuGet.Packaging;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MVC_Core.Controllers
{
    public class AccountController : Controller
    {
        #region Dependency Injection
        /*
         * We have to Register Identity to the application Services in Program.cs file 
         */
        private readonly IAccountMangerService _accountMangerService;

        public AccountController ( IAccountMangerService accountMangerService)
        { 
            _accountMangerService = accountMangerService;
        }
        #endregion

        #region Register

        #region Get
        // Get Http
        public IActionResult Register()
        {
            return View(new RegisterCredentialsDTO());
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCredentialsDTO data)
        {

            var RegisterationResult = await _accountMangerService.RegisterAsync(data);

            TempData["Message"] = RegisterationResult.Message;
            return Redirect("/Account/Login");

        }
        #endregion

        #region Login

        #region GET
        // Get Http
        public IActionResult Login()
        {
            return View(new LoginCredentialsDTO());
        } 
        #endregion

        [HttpPost]
        public async Task<IActionResult> Login(LoginCredentialsDTO data)
        {
            /*
             * we have to use signinmanger.passwordsigninasync
             * and check if it succeed, require Two Factor, or locked
             * 
             */

            var LoginResult = await _accountMangerService.LoginAsync(data);

            return Json(LoginResult);
        }
        #endregion
    }
}
