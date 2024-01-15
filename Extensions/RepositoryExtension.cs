using MVC_Core.Models;
using MVC_Core.Repositories;
using MVC_Core.Services;

namespace MVC_Core.Extensions
{
    public static class RepositoryExtension
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Student>), typeof(StudentRepository));
            services.AddScoped(typeof(IRepository<School>), typeof(SchoolRepository));
            services.AddScoped(typeof(IAccountMangerService), typeof(AccountMangerService));
        }
    }
}
