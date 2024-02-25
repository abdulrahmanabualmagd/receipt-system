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
        Task<ProfileDto> GetProfile(ClaimsPrincipal user);
        Task<int> GetCustomerId(ClaimsPrincipal user);
    }
}
