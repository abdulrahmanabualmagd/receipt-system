using Core.AccountManger;
using Core.Entities.UserIdentity;
using Core.IServices;
using Core.IUoW;
using Core.SchoolServcie;
using Core.StudentService;
using Infrastructure.UoW;
using Microsoft.AspNetCore.Identity;
using Services;


namespace Web.Extensions
{
    public static class ServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccountMangerService, AccountMangerService>();
            services.AddScoped<SignInManager<ApplicationUser>>();
            services.AddScoped<UserManager<ApplicationUser>>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<ICountsSerivce, CountsService >();

        }
    }
}
