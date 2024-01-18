using Microsoft.AspNetCore.Identity;
using MVC_Core.Data;
using MVC_Core.Models;

namespace MVC_Core.Extensions
{
    public static class IdentityExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();
        }
    }
}
