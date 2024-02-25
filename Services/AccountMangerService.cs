using AutoMapper;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Core.DTOs;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Core.AccountManger;
using Core.Entities.UserIdentity;
using Core.Entities.Application;
using Core.IUoW;

namespace Services
{
    public class AccountMangerService : IAccountMangerService
    {

        #region Dependency Injection
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _autoMapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountMangerService(
            UserManager<ApplicationUser> userManger,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManger,
            IConfiguration configuration,
            IMapper autoMapper,
            IUnitOfWork unitOfWork
            )
        {
            _userManager = userManger;
            _signInManager = signInManager;
            _roleManger = roleManger;
            _configuration = configuration;
            _autoMapper = autoMapper;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Register Async
        public async Task<bool> RegisterAsync(RegisterCredentialsDTO registerCredentialsDTO)
        {
            #region Check if Username of Password is repeated
            if (await _userManager.FindByEmailAsync(registerCredentialsDTO.Email) is not null)
                return false;

            if (await _userManager.FindByNameAsync(registerCredentialsDTO.UserName) is not null)
                return false;
            #endregion

            #region Map User Inputs
            ApplicationUser user = _autoMapper.Map<RegisterCredentialsDTO, ApplicationUser>(registerCredentialsDTO);
            #endregion

            #region Create User
            if (!(await _userManager.CreateAsync(user, registerCredentialsDTO.Password)).Succeeded)
                return false;
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
                    return false;
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
                    return false;
            }
            #endregion

            #region Assign Role to User
            if (!(await _userManager.AddToRoleAsync(user, "User")).Succeeded)
            {
                return false;
            }
            #endregion

            #endregion

            #region Add Claims to user
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.NameIdentifier, user.Id));
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, registerCredentialsDTO.FirstName + " " + registerCredentialsDTO.LastName));
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.MobilePhone, registerCredentialsDTO.PhoneNumber));
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, registerCredentialsDTO.Email));
            #endregion

            #region RegisterCustomer
            if (!(await RegisterCustomerAsync(user)))
                return false; 
            #endregion

            return true;
        }
        #endregion

        #region AddCustomer
        public async Task<bool> RegisterCustomerAsync(ApplicationUser user)
        {
            Customer customer = new Customer
            {
                UserId =  user.Id,
                Name = user.FirstName + " " + user.LastName,
                Phone = user.PhoneNumber,
                Balance = 100000,
            };

            try
            {
                await _unitOfWork.Repository<Customer>().AddAsync(customer);
                await _unitOfWork.CompleteAsync();
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region LoginAsync
        public async Task<bool> LoginAsync(LoginCredentialsDTO loginCredentialsDTO)
        {
            #region Check Password and Email
            var user = await _userManager.FindByEmailAsync(loginCredentialsDTO.Email);
            if (user is null || !await _userManager.CheckPasswordAsync(user, loginCredentialsDTO.Password))
                return false;
            #endregion

            #region SignIn
            if (!(await _signInManager.PasswordSignInAsync(user, loginCredentialsDTO.Password, true, false)).Succeeded)
                return false;
            #endregion

            return true;
        }
        #endregion

        #region LogoutAsync
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();        
        }
        #endregion

        #region Generate JWT Token
        public async Task<AccountMangerDto> GenerateJWT(ApplicationUser user)
        {
            #region Assign Claims
            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName ?? "N/A"),
                new Claim(ClaimTypes.Email, user.Email ?? "N/A"),
                new Claim(ClaimTypes.Role, "User")
            };

            if (!(await _userManager.AddClaimsAsync(user, userClaims)).Succeeded)
            {
                return new AccountMangerDto { Message = "Unable To Add Claims" };
            }
            #endregion

            #region Prepare SecretKey
            var keyString = _configuration.GetSection("SecretKey").ToString() ?? "N/A";
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
                IsAuthenticated = true,
                Success = true,
            };
        }
        #endregion
    }
}
