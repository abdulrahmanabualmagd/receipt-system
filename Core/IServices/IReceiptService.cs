using Core.Entities.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IReceiptService
    {
        Task<IEnumerable<Receipt>> UserGetAllAsync(ClaimsPrincipal user);
        Task<Receipt> UserGetByIdAsync(ClaimsPrincipal user, int itemId);
        Task<bool> UserAddAsync(ClaimsPrincipal user, Receipt item);
        Task<Receipt> GetUserOpenReceiptAsync(ClaimsPrincipal user);
        Task<bool> CreateReceiptAsync(ClaimsPrincipal user, List<Item> items);
    }
}
