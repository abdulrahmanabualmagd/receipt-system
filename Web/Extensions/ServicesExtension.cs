using Core.AccountManger;
using Core.Entities.Application;
using Core.Entities.UserIdentity;
using Core.IServices;
using Core.IUoW;
using Infrastructure.UoW;
using Microsoft.AspNetCore.Identity;
using Services;


namespace Web.Extensions
{
    public static class ServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Authentication & Authorization
            services.AddScoped<IAccountMangerService, AccountMangerService>();
            services.AddScoped<SignInManager<ApplicationUser>>();
            services.AddScoped<UserManager<ApplicationUser>>();

            // UOW
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Special Services
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IProfileService, ProfileService>();

            // Entities Services
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
