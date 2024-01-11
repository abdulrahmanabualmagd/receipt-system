using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using MVC_Core.DTOs;
using MVC_Core.Models;
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
         * We have to Register Identity to the application Services in Progam.cs file 
         */
        private readonly UserManager<User> _userManger;
        private readonly RoleManager<IdentityRole> _roleManger;
        private readonly IConfiguration _configuration; 

        public AccountController (UserManager<User> userManger, RoleManager<IdentityRole> roleManger, IConfiguration configuration)
        {
            _userManger = userManger;
            _roleManger = roleManger;
            _configuration = configuration;
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
            #region New User Instance
            User NewUser = new User
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };
            #endregion

            #region Create User
            var CreationResult = await _userManger.CreateAsync(NewUser, data.Password);

            // In Case User Created Successfully 
            if (!CreationResult.Succeeded)
            {
                return BadRequest("Failed to Register User");
            }
            #endregion

            #region Assign Role

            #region check Admin
            bool CheckAdminExistance = await _roleManger.RoleExistsAsync("Admin");
            if (!CheckAdminExistance)
            {
                // Create new role for admin
                var adminRole = new IdentityRole("Admin");

                // Set a custom concurrency stamp based on the role name 
                adminRole.ConcurrencyStamp = Guid.NewGuid().ToString();

                // Add the new role to the Rols
                var adminRoleCreation = await _roleManger.CreateAsync(adminRole);

                // Check the addition result
                if (!adminRoleCreation.Succeeded)
                {
                    return BadRequest();
                }
            }
            #endregion

            #region Check User
            // check if Role Exist
            bool CheckRoleExistance = await _roleManger.RoleExistsAsync("User");

            // In case not Create new one 
            if (!CheckRoleExistance)
            {
                // Create new role for user
                var UserRole = new IdentityRole("User");

                // Set a custom concurrency stamp based on the role name
                UserRole.ConcurrencyStamp = Guid.NewGuid().ToString();

                // Add User role to the roles
                var CheckRoleCreation = await _roleManger.CreateAsync(UserRole);

                // Check the addition result 
                if (!CheckRoleCreation.Succeeded)
                {
                    return BadRequest();
                }
            } 
            #endregion

            // Assign Role 'User' to the new registered User
            var RoleAssination = await _userManger.AddToRoleAsync(NewUser, "User");
            #endregion

            #region Assign Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, NewUser.Id.ToString()),
                new Claim(ClaimTypes.Name, NewUser.UserName),
                new Claim(ClaimTypes.Email, NewUser.Email),
                new Claim(ClaimTypes.Role, "User")
            };

            var ClaimAssinationResult = await _userManger.AddClaimsAsync(NewUser, claims);
            #endregion

            TempData["Message"] = "Account Registered Successfully!";
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

            #region Verify Email
            var user = await _userManger.FindByEmailAsync(data.Email);

            if (user == null)
            {
                return BadRequest();
            }
            #endregion

            #region User Lockout Check
            var IsLocked = await _userManger.IsLockedOutAsync(user);
            if (IsLocked)
            {
                return BadRequest("Is Locked");
            }
            #endregion

            #region Verify Password
            bool passwordVerification = await _userManger.CheckPasswordAsync(user, data.Password);

            if (!passwordVerification)
            {
                await _userManger.AccessFailedAsync(user);
                return BadRequest("Wrong Password");
            }
            #endregion

            // Prepare Token

            #region Packaging Claims
            var claims = await _userManger.GetClaimsAsync(user);
            #endregion

            #region Prepare SecretKey
            var keyString = _configuration.GetValue<string>("SecretKey") ?? "";
            var keyBytes = Encoding.ASCII.GetBytes(keyString);
            var key = new SymmetricSecurityKey(keyBytes);
            #endregion

            #region Token Signing
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: "MVCCore",
                audience:"Listeners",
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(1)
                //,notBefore: DateTime.UtcNow
                );
            #endregion

            #region Generate Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwt);
            #endregion

            TempData["Message"] = "Loggedin Successfully!";
            return Json(new {Token = tokenString});
        }
        #endregion
    }
}
