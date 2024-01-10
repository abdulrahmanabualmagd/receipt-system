using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVC_Core.DTOs;
using MVC_Core.Models;
using System.Security.Claims;

namespace MVC_Core.Controllers
{
    public class AccountController : Controller
    {
        #region Dependency Injection
        /*
         * We have to Register Identity to the application Services in Progam.cs file 
         */
        private UserManager<User> _userManger;
        private RoleManager<IdentityRole> _roleManger;

        public AccountController (UserManager<User> userManger, RoleManager<IdentityRole> roleManger)
        {
            _userManger = userManger;
            _roleManger = roleManger;
        }
        #endregion

        #region Register
        // Get Http
        public IActionResult Register()
        {
            var credentials = new RegisterCredentialsDto();
            return View(credentials);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCredentialsDto data)
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
                return BadRequest();
            }
            #endregion

            #region Assign Role
            // check if Role Exist
            bool CheckRoleExistance = await _roleManger.RoleExistsAsync("User");

            // In case not Create new one 
            if (!CheckRoleExistance)
            {
                // Add Role to the user
                var UserRole = new IdentityRole("User");
                var CheckRoleCreation = await _roleManger.CreateAsync(UserRole);

                if (!CheckRoleCreation.Succeeded)
                {
                    return BadRequest();
                }
            }

            // In Case the Role is exist Assign it to the user
            var RoleAssination = await _userManger.AddToRoleAsync(NewUser, "User");
            #endregion

            #region Assign Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, NewUser.Id.ToString()),
                new Claim(ClaimTypes.Role, "Client")
            };
            var ClaimAssinationResult = await _userManger.AddClaimsAsync(NewUser, claims);
            #endregion


            TempData["Message"] = "Register Successfully";
            return Redirect("Home/Crud");
        }
        #endregion
    }
}
