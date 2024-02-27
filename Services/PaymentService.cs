using Core.Entities.Application;
using Core.IServices;
using Core.IUoW;
using System.Security.Claims;
using Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public class PaymentService : IPaymentService
    {
        #region Dependency Injection
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProfileService _profileService;
        private readonly IReceiptService _receiptService;
        public PaymentService(IUnitOfWork unitOfWork, IReceiptService receiptService, IProfileService profileService)
        {
            _unitOfWork = unitOfWork;
            _receiptService = receiptService;
            _profileService = profileService;
        }
        #endregion

        #region ReceiptPayment
        public async Task<CheckDto> UserAddAsync(ClaimsPrincipal user, PaymentCredentialsDto paymentCredentialsDto)
        {
            if (paymentCredentialsDto.Amount == 0)
            {
                return new CheckDto 
                {
                    Message = "You've entered Zero!",
                    IsValid = true,
                };
            }

            // The Transaction Change
            decimal change = 0;
            // The Amount to Pay
            decimal amountToPay;

            // Get Receipt and Check Existance
            var receipt = await _receiptService.UserGetByIdAsync(user, paymentCredentialsDto.ReceiptId);
            if (receipt == null)
                return new CheckDto { Message = "Can't Find Receipt!" };

            // Create new Payment
            var payment = new Payment
            {
                PaymentDate = DateTime.UtcNow
            };

            // Check if the Receipt is Completed!
            amountToPay = receipt.TotalAmount - receipt.PaidAmount;
            if (amountToPay <= 0)
                return new CheckDto { Message = "The Receipt Have Been Already Paid", IsValid = true };

            // Customer Change Calculation
            if (paymentCredentialsDto.Amount < amountToPay)
                payment.Amount = paymentCredentialsDto.Amount;
            else
            {
                payment.Amount = amountToPay;
                change = paymentCredentialsDto.Amount - amountToPay;
            }

            receipt.PaidAmount += payment.Amount;

            // Get the money from the cutsomer 
            if (!(await _profileService.CustomerPayAsync(user, payment.Amount)))
                return new CheckDto { Message = "You don't have enough balance to complete the transaction!" };

            // Add Payment to Receipt
            receipt.Payments.Add(payment);

            // Update Receipt and User Balance
            _unitOfWork.Repository<Receipt>().Update(receipt);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch { return new CheckDto { Message = "Can't Complete Transaction!" }; }

            if (change > 0)
                return new CheckDto { IsValid = true, Message = $"Transaction Completed Successfully and ${change} would be added to you balance", Value = change };

            return new CheckDto { IsValid = true, Message = "Transaction Completed Successfully!", Value = change };
        } 
        #endregion

        #region Get All user Receipt Payments
        public async Task<IEnumerable<Payment>> UserGetAllAsync(ClaimsPrincipal user)
        {
            // Get CustomerId
            var customerId = await _profileService.GetCustomerIdAsync(user);

            // Get All Payments
            return await _unitOfWork.Repository<Payment>().FindAllAsync(c => c.Receipt.CustomerId == customerId, ["Receipt"]);   
        }
        #endregion

        #region Get Payment By Id
        public async Task<IEnumerable<Payment>> UserGetByIdAsync(ClaimsPrincipal user, int receiptId)
        {
            // Get CustomerId
            var customerId = await _profileService.GetCustomerIdAsync(user);

            // Get All Payments
            return await _unitOfWork.Repository<Payment>().FindAllAsync(c => c.Receipt.CustomerId == customerId && c.ReceiptId == receiptId, ["Receipt"]);
        } 
        #endregion
    }
}
