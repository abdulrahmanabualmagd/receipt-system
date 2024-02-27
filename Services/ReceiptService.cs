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
using Core.DTOs;

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

        public async Task<IEnumerable<Receipt>> UserGetPagesAsync(ClaimsPrincipal user, PaginationDto pagination)
        {
            var customerId = await _profileService.GetCustomerIdAsync(user);

            return await _unitOfWork.Repository<Receipt>().GetPageAsync(pagination.Page, pagination.Size, c=> c.CustomerId == customerId , null);
        }
        public async Task<int> UserGetTotalPagesAsync(ClaimsPrincipal user, int pageSize)
        {
            var customerId = await _profileService.GetCustomerIdAsync(user);

            return await _unitOfWork.Repository<Receipt>().GetTotalPagesAsync(pageSize, c=> c.CustomerId == customerId , null);
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

            #region Moving Quantities
            bool flag = false;
            foreach (var item in itemsreceiopt)
            {
                flag = false;

                foreach (var item2 in items)
                {
                    if (item2.Id == item.Id)
                    {
                        flag = true;
                        item.Quantity = item2.Quantity;
                        continue;
                    }
                }
                if (!flag)
                {
                    itemsreceiopt.Remove(item);
                }
            }
            #endregion



            #region Ignored
            //// Check for the stock limit
            //for (int i = 0; i < items.Count; i++)
            //{
            //    if (items[i].Quantity > items[i].StockAmount)
            //        return false;

            //    receipt.TotalAmount += items[i].Price * items[i].Quantity;

            //    receipt.Items.ElementAt(i).Quantity = items[i].Quantity;
            //}

            //for (int i = 0; i < items.Count; i++)
            //{
            //    if (items[i].Quantity > items[i].StockAmount)
            //        return false;

            //    receipt.TotalAmount += items[i].Price * items[i].Quantity;

            //    receipt.Items.ElementAt(i).Quantity = items[i].Quantity;
            //} 
            #endregion

            receipt.ReleasedDate = DateTime.UtcNow;

            _unitOfWork.Repository<Receipt>().Update(receipt);
            await _unitOfWork.CompleteAsync();


            #region Update Item Quantities
            foreach (var item in itemsreceiopt)
            {
                item.StockAmount -= item.Quantity;
                item.Quantity = 0;
                await UpdateItemAsync(item);
            }
            #endregion


            return true;
        }
        #endregion

        public async Task<bool> UpdateItemAsync(Item item)
        {
            _unitOfWork.Repository<Item>().Update(item);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch { return false; }

            return true;
        }
    }
}
