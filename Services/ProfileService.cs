using Core.DTOs;
using Core.Entities.Application;
using Core.Entities.UserIdentity;
using Core.IServices;
using Core.IUoW;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProfileService : IProfileService
    {
        #region Dependency Injection
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public ProfileService(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        #endregion

        public async Task<ProfileDto> GetProfile(ClaimsPrincipal user)
        {
            // Check user identity
            if (user == null) 
                return new ProfileDto();

            var CurrentUser = await _userManager.GetUserAsync(user);

            // Check User 
            if (CurrentUser == null)
                return new ProfileDto();

            var claims = await _userManager.GetClaimsAsync(CurrentUser);

            // Check claims
            if (claims == null)
                return new ProfileDto();

            var userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var customerId = (await _unitOfWork.Repository<Customer>().FindAsync(c => c.UserId == userId)).Id;

            var receipts = (await _unitOfWork.Repository<Receipt>().FindAllAsync(c=> c.CustomerId == customerId)).ToList();
            

            return new ProfileDto
            {
                Id = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                Name = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                Phone = claims.FirstOrDefault(c => c.Type == ClaimTypes.MobilePhone)?.Value,
                Email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                Address = "N/A",
                Receipts = receipts
            };
        }

        public async Task<int> GetCustomerId(ClaimsPrincipal user)
        {
            var currentUser = await _userManager.GetUserAsync(user);

            var claims = await _userManager.GetClaimsAsync(currentUser);

            var userId = claims.FirstOrDefault(c=> c.Type == ClaimTypes.NameIdentifier)?.Value;

            var customerId = (await _unitOfWork.Repository<Customer>().FindAsync(c => c.UserId == userId)).Id;

            return customerId;
        }
    }
}
