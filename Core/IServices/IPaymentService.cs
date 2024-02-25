using Core.Entities.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> UserGetAllAsync(ClaimsPrincipal user);
        Task<bool> UserAddAsync(ClaimsPrincipal user, Payment payment);
    }
}
