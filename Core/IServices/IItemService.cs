using Core.Entities.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllAsync();

        Task<IEnumerable<Item>> UserGetAllAsync(ClaimsPrincipal user, int receiptId);
        Task<bool> UserAddAsync(ClaimsPrincipal user, int itemId);
        Task<bool> UserDeleteAsync(ClaimsPrincipal user, int itemId);
    }
}
