using Microsoft.AspNetCore.Identity;
using Core.Entities.UserIdentity;
using Infrastructure.Data.Contexts.Identity;

namespace Web.Extensions
{
    public static class IdentityExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<AppIdentityDbContext>()
               .AddDefaultTokenProviders();
        }
    }
}
