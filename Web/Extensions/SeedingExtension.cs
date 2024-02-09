using Infrastructure.Data.Contexts.Application;
using Infrastructure.Data.Contexts.Identity;
using Infrastructure.Data.Seeds.Application;
using Microsoft.EntityFrameworkCore;

namespace Web.Extensions
{
    public static class SeedingExtension
    {
        public static async void SeedAsync(this IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;
            var LoggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            var identityDbContext = services.GetRequiredService<AppIdentityDbContext>();
            var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();

            try
            {
                await identityDbContext.Database.MigrateAsync();
                //await IdentitySeed.SeedIdentityAsync(identityDbContext);
                await ApplicationSeed.SeedApplicationAsync(applicationDbContext);
            }
            catch (Exception ex) 
            {
                var logger = LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error happened while trying to migrate stored static files");
            }
        }
    }
}
