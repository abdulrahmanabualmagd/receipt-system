using Core.Entities.Application;
using Core.IServices;
using Core.IUoW;
using System.Security.Claims;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PaymentService : IPaymentService
    {
        #region Dependency Injection
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReceiptService _receiptService;
        public PaymentService(IUnitOfWork unitOfWork, IReceiptService receiptService)
        {
            _unitOfWork = unitOfWork;
            _receiptService = receiptService;
        }
        #endregion

        public Task<bool> UserAddAsync(ClaimsPrincipal user, Payment payment)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> UserGetAllAsync(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

    }
}
