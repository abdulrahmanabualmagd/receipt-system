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

        #region GetProfile
        public async Task<ProfileDto> GetProfileAsync(ClaimsPrincipal user)
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

            var receipts = (await _unitOfWork.Repository<Receipt>().FindAllAsync(c => c.CustomerId == customerId)).ToList();

            var customerBalance = (await _unitOfWork.Repository<Customer>().FindAsync(c => c.Id == customerId)).Balance;

            return new ProfileDto
            {
                Id = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                Name = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                Phone = claims.FirstOrDefault(c => c.Type == ClaimTypes.MobilePhone)?.Value,
                Email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                Balance = customerBalance,
                Address = "N/A",
                Receipts = receipts
            };
        }
        #endregion

        #region GetCustomerId
        public async Task<int> GetCustomerIdAsync(ClaimsPrincipal user)
        {
            var currentUser = await _userManager.GetUserAsync(user);

            var claims = await _userManager.GetClaimsAsync(currentUser);

            var userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var customerId = (await _unitOfWork.Repository<Customer>().FindAsync(c => c.UserId == userId)).Id;

            return customerId;
        }
        #endregion

        #region Customer Pay
        public async Task<bool> CustomerPayAsync(ClaimsPrincipal user, decimal amount)
        {
            var customerID = await GetCustomerIdAsync(user);

            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(customerID);

            if (customer.Balance < amount)
                return false;

            customer.Balance = customer.Balance - amount;

            _unitOfWork.Repository<Customer>().Update(customer);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch { return false; }

            return true;
        }
        #endregion

        #region Customer Transaction Change
        public async Task<bool> CustomerAddChange(ClaimsPrincipal user, decimal change)
        {
            var customerID = await GetCustomerIdAsync(user);

            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(customerID);

            customer.Balance += change;

            _unitOfWork.Repository<Customer>().Update(customer);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch { return false; }

            return true;
        }
        #endregion
    }
}
