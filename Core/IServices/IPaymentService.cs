using Core.DTOs;
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
        Task<IEnumerable<Payment>> UserGetPagesAsync(ClaimsPrincipal user, PaginationDto pagination);
        Task<int> UserGetTotalPagesAsync(ClaimsPrincipal user, int pageSize);
        Task<IEnumerable<Payment>> UserGetByIdAsync(ClaimsPrincipal user, int receiptId);
        Task<CheckDto> UserAddAsync(ClaimsPrincipal user, PaymentCredentialsDto Payment);
    }
}
