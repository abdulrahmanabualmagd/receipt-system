using Core.DTOs;
using Core.Entities.UserIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IProfileService
    {
        Task<ProfileDto> GetProfileAsync(ClaimsPrincipal user);
        Task<int> GetCustomerIdAsync(ClaimsPrincipal user);

        Task<bool> CustomerAddChange(ClaimsPrincipal user, decimal change);
        Task<bool> CustomerPayAsync(ClaimsPrincipal user, decimal amount);
    }
}
