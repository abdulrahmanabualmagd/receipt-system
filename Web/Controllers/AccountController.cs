using Core.AccountManger;
using Core.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        #region Dependency Injection
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

            if (ModelState.IsValid)
            {
                var RegisterationResult = await _accountMangerService.RegisterAsync(data);

                if (RegisterationResult)
                    return Redirect("/Account/Login");
            }

            TempData["Message"] = "Wrong formt!";
            return Redirect("/Account/Register");
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

        #region POST
        [HttpPost]
        public async Task<IActionResult> Login(LoginCredentialsDTO data)
        {
            if(ModelState.IsValid)
            {
                var LoginResult = await _accountMangerService.LoginAsync(data);

                if (LoginResult)
                    return RedirectToAction("Index", "Home");
            }

            TempData["Message"] = "In Correct Email or password";
            return RedirectToAction("Login");
        } 
        #endregion
        #endregion

        #region Logout
        #region GET
        public async Task<IActionResult> Logout()
        {
            await _accountMangerService.LogoutAsync();
            return RedirectToAction("Login", "Account");
        } 
        #endregion
        #endregion

        #region External Login
        public async Task ExternalLogin(string provider)
        {

            if (string.IsNullOrEmpty(provider))
                return;

            await HttpContext.ChallengeAsync(provider,
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("ExternalLoginCallback", new { provider = provider })
                });
        }
        #endregion

        #region External Login Call Back
        public async Task<IActionResult> ExternalLoginCallback(string provider)
        {

            if (string.IsNullOrEmpty(provider))
                return BadRequest("There is no provider sent");

            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);


            var allClaims = result.Principal?.Claims.ToList();

            var profilePictureUrl = result.Principal.FindFirstValue("picture");


            var emailClaim = allClaims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var nameClaim = allClaims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var givenname = allClaims?.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;
            var surname = allClaims?.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;


            var responseData = new
            {
                Name = nameClaim,
                Email = emailClaim,
                Givenname = givenname,
                Surname = surname,
            };

            return Json(responseData);
        } 
        #endregion

    }
}
