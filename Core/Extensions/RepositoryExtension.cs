using Infrastructure.IServices;
using Web.Services;
using Infrastructure.UoW;
using Infrastructure.UoW;

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
