using Core.Entities.Application;
using Core.IServices;
using Core.IUoW;
using System.Security.Claims;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Services
{
    public class ReceiptService : IReceiptService
    {
        #region Dependency Injection
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProfileService _profileService;
        public ReceiptService(IUnitOfWork unitOfWork, IProfileService profileService)
        {
            _unitOfWork = unitOfWork;
            _profileService = profileService;
        }
        #endregion

        #region Add User Receipt
        public async Task<bool> UserAddAsync(ClaimsPrincipal user, Receipt item)
        {
            var customerId = await _profileService.GetCustomerIdAsync(user);

            item.CustomerId = customerId;

            await _unitOfWork.Repository<Receipt>().AddAsync(item);

            await _unitOfWork.CompleteAsync();

            return true;
        } 
        #endregion

        #region Get All User Receipts
        public async Task<IEnumerable<Receipt>> UserGetAllAsync(ClaimsPrincipal user)
        {
            var customerId = await _profileService.GetCustomerIdAsync(user);

            // Get All Receipts
            var receipts = await _unitOfWork.Repository<Receipt>().FindAllAsync(c => c.CustomerId == customerId);

            return receipts;
        }
        #endregion

        #region Get User Receipt by Id
        public async Task<Receipt> UserGetByIdAsync(ClaimsPrincipal user, int itemId)
        {
            var customerId = await _profileService.GetCustomerIdAsync(user);
            var receipt = await _unitOfWork.Repository<Receipt>().FindAsync(c => c.CustomerId == customerId && c.Id == itemId, ["Items", "Customer", "Payments"]);
            return receipt;
        }
        #endregion

        #region Get User Open Receipt
        public async Task<Receipt> GetUserOpenReceiptAsync(ClaimsPrincipal user)
        {
            var customerId = await _profileService.GetCustomerIdAsync(user);

            // Get All Receipt
            var receipt = await _unitOfWork.Repository<Receipt>().FindAsync(c => c.CustomerId == customerId && c.TotalAmount == 0, ["Payments", "Items", "Customer"]);

            // Create new receipt if there is not receipts
            if (receipt == null)
            {
                receipt = new Receipt
                {
                    CustomerId = customerId,
                };

                await _unitOfWork.Repository<Receipt>().AddAsync(receipt);
                await _unitOfWork.CompleteAsync();
            }

            return receipt;
        }
        #endregion

        #region Create Receipt
        public async Task<bool> CreateReceiptAsync(ClaimsPrincipal user, List<Item> items)
        {

            var receipt = await GetUserOpenReceiptAsync(user);
            var itemsreceiopt = receipt.Items.ToList();

            decimal total = 0;
            // Check for the stock limit
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Quantity > items[i].StockAmount)
                    return false;

                receipt.TotalAmount += items[i].Price * items[i].Quantity;

                receipt.Items.ElementAt(i).Quantity = items[i].Quantity;
            }


            receipt.ReleasedDate = DateTime.UtcNow;

            _unitOfWork.Repository<Receipt>().Update(receipt);
            await _unitOfWork.CompleteAsync();

            return true;
        }
        #endregion
    }
}
