using MVC_Core.Models;
using MVC_Core.Repositories;
using MVC_Core.Services;
using MVC_Core.UoW;

namespace MVC_Core.Extensions
{
    public static class RepositoryExtension
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAccountMangerService), typeof(AccountMangerService));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
