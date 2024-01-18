using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using MVC_Core.DTOs;
using MVC_Core.IServices;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.DotNet.Scaffolding.Shared;

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
             */

            var LoginResult = await _accountMangerService.LoginAsync(data);

            return Json(LoginResult);
        }
        #endregion


        public async Task ExternalLogin()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("ExternalLoginCallback")
                });
        }

        public async Task<IActionResult> ExternalLoginCallback()
        {

            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);


            var allClaims = result.Principal?.Claims.ToList();

            var profilePictureUrl = result.Principal.FindFirstValue("picture");


            var emailClaim  = allClaims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var nameClaim   = allClaims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var givenname    = allClaims?.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;
            var surname    = allClaims?.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;


            var responseData = new
            {
                Name = nameClaim,
                Email = emailClaim,
                Givenname = givenname,
                Surname = surname,
            };

            return Json(responseData);
        }

    }
}
