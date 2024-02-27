using Core.Entities.Application;
using Core.IServices;
using Core.IUoW;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Core.Entities.UserIdentity;
using Core.DTOs;
using System.Runtime.InteropServices.Marshalling;

namespace Services
{
    public class ItemService : IItemService
    {
        #region Dependency Injection
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReceiptService _receiptService;
        public ItemService(IUnitOfWork unitOfWork, IReceiptService receiptService)
        {
            _unitOfWork = unitOfWork;
            _receiptService = receiptService;            
        }
        #endregion

        #region Get All
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Item>().GetAllAsync(["Category"]);
        }

        public async Task<IEnumerable<Item>> GetPageAsync(PaginationDto pagination)
        {
            return await _unitOfWork.Repository<Item>().GetPageAsync(pagination.Page, pagination.Size,["Category"]);
        }
        public async Task<int> GetTotalPagesAsync(int pageSize)
        {
            return await _unitOfWork.Repository<Item>().GetTotalPagesAsync(pageSize);
        }
        #endregion


        // Auth

        #region Add Item
        public async Task<bool> UserAddAsync(ClaimsPrincipal user, int itemId)
        {
            var receipt = await _receiptService.GetUserOpenReceiptAsync(user);

            // Get Item
            var item = await _unitOfWork.Repository<Item>().GetByIdAsync(itemId);

            item.Quantity = 1;

            receipt.Items.Add(item);

            await _unitOfWork.CompleteAsync();

            return true;
        }
        #endregion

        #region Delete Item
        public async Task<bool> UserDeleteAsync(ClaimsPrincipal user, int itemId)
        {
            var receipt = await _receiptService.GetUserOpenReceiptAsync(user);

            var item = await _unitOfWork.Repository<Item>().GetByIdAsync(itemId);

            receipt.Items.Remove(item);

            await _unitOfWork.CompleteAsync();

            return true;
        }
        #endregion

        #region Update Item
        public async Task<bool> UpdateAsync(Item item)
        {
            _unitOfWork.Repository<Item>().Update(item);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch { return false; }

            return true;
        }
        #endregion

        #region Get All Receipt Items
        public async Task<IEnumerable<Item>> UserGetAllAsync(ClaimsPrincipal user, int receiptId)
        {
            var receipt = await _receiptService.UserGetByIdAsync(user, receiptId);

            return receipt.Items;
        } 
        #endregion

    }
}
