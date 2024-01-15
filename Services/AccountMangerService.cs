using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MVC_Core.DTOs;
using MVC_Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MVC_Core.Services
{
    public class AccountMangerService : IAccountMangerService
    {

        #region Dependency Injection
        private readonly UserManager<User> _userManger;
        private readonly RoleManager<IdentityRole> _roleManger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _autoMapper;

        public AccountMangerService(
            UserManager<User> userManger,
            RoleManager<IdentityRole> roleManger,
            IConfiguration configuration,
            IMapper autoMapper
            )
        {
            _userManger = userManger;
            _roleManger = roleManger;
            _configuration = configuration;
            _autoMapper = autoMapper;
        }
        #endregion

        #region Register Async
        public async Task<AccountMangerDto> RegisterAsync(RegisterCredentialsDTO registerCredentialsDTO)
        {
            #region Check if Username of Password is repeated
            if (await _userManger.FindByEmailAsync(registerCredentialsDTO.Email) is not null)
            {
                return new AccountMangerDto { Message = "Email is used before!" };
            }

            if (await _userManger.FindByNameAsync(registerCredentialsDTO.UserName) is not null)
            {
                return new AccountMangerDto { Message = "Username is used before!" };
            }
            #endregion

            #region Map User Inputs
            User user = _autoMapper.Map<RegisterCredentialsDTO, User>(registerCredentialsDTO);
            #endregion

            #region Create User
            if (!(await _userManger.CreateAsync(user, registerCredentialsDTO.Password)).Succeeded)
            {
                return new AccountMangerDto { Message = "Unable to Create User" };
            }
            #endregion

            #region Assign Roles 

            #region Check for Admin Role Existance
            if (!await _roleManger.RoleExistsAsync("Admin"))
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
                    return new AccountMangerDto { Message = "Unable to create Admin Role" };
                }
            }
            #endregion

            #region Check For User Role Existance 
            if (!await _roleManger.RoleExistsAsync("User"))
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
                    return new AccountMangerDto { Message = "Unabel to create User Role" };
                }
            }
            #endregion

            #region Assign Role to User
            if (!(await _userManger.AddToRoleAsync(user, "User")).Succeeded)
            {
                return new AccountMangerDto { Message = "Unable to Assign Role to User" };
            }
            #endregion

            #endregion

            #region Generate Token
            var TokenGenerationResult = await GenerateJWT(user);
            var token = TokenGenerationResult.Token;
            #endregion

            return new AccountMangerDto
            {
                Message = "Account Created Successfully",
                Token = token,
                IsAuthenticated = true
            };
        }
        #endregion

        #region LoginAsync
        public async Task<AccountMangerDto> LoginAsync(LoginCredentialsDTO loginCredentialsDTO)
        {
            #region Check Password and Email
            var user = await _userManger.FindByEmailAsync(loginCredentialsDTO.Email);
            if (user is null || !await _userManger.CheckPasswordAsync(user, loginCredentialsDTO.Password))
            {
                return new AccountMangerDto { Message = "Wrong Email or Password" };
            }
            #endregion

            #region Generate Token
            var TokenGenerationResult = await GenerateJWT(user);
            var token = TokenGenerationResult.Token;
            #endregion

            return new AccountMangerDto
            {
                Message = "Loggedin Successsfully!",
                IsAuthenticated = true,
                Token = token
            };
        }
        #endregion

        #region Generate JWT Token
        public async Task<AccountMangerDto> GenerateJWT(User user)
        {

            #region Assign Claims
            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName ?? "N/A"),
                new Claim(ClaimTypes.Email, user.Email ?? "N/A"),
                new Claim(ClaimTypes.Role, "User")
            };

            if (!(await _userManger.AddClaimsAsync(user, userClaims)).Succeeded)
            {
                return new AccountMangerDto { Message = "Unable To Add Claims" };
            }
            #endregion

            #region Prepare SecretKey
            var keyString = _configuration.GetValue<string>("SecretKey") ?? "";
            var keyBytes = Encoding.ASCII.GetBytes(keyString);
            var key = new SymmetricSecurityKey(keyBytes);
            #endregion

            #region Token Signing
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                claims: userClaims,
                signingCredentials: signingCredentials,
                issuer: "MVCCore",
                audience: "Listeners",
                expires: DateTime.UtcNow.AddHours(1),
                notBefore: DateTime.UtcNow
                );
            #endregion

            #region Generate Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(jwt);
            #endregion

            return new AccountMangerDto
            {
                Message = "Token Generated Successfully!",
                Token = token,
                IsAuthenticated = true
            };
        }
        #endregion

    }
}
