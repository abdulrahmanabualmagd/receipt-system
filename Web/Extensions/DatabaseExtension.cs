using Core.Entities;
using Infrastructure.Data.Contexts.Application;
using Infrastructure.Data.Contexts.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Web.Extensions
{
    public static class DatabaseExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, ConfigurationManager? configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(
                    configuration?.GetConnectionString("DefaultConnection"),
                    options => options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                    ));

            services.AddDbContext<AppIdentityDbContext>(
            options => options.UseSqlServer(
                    configuration?.GetConnectionString("IdentityConnection"),
                    options => options.MigrationsAssembly(typeof(AppIdentityDbContext).Assembly.FullName)
            ));
        }
    }
}