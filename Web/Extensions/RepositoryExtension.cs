using Core.AccountManger;
using Core.IUoW;
using Core.SchoolServcie;
using Core.StudentService;
using Infrastructure.UoW;
using Services;


namespace Web.Extensions
{
    public static class RepositoryExtension
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountMangerService, AccountMangerService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISchoolService, SchoolService>();

        }
    }
}
