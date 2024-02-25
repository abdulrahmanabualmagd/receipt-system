using Core.Entities.Application;
using Core.Entities.UserIdentity;
using Infrastructure.Data.Contexts.Application;
using Infrastructure.Data.Contexts.Identity;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Infrastructure.Data.Seeds.Identity
{
    public static class IdentitySeed
    {
        public static async Task SeedIdentityAsync(AppIdentityDbContext context)
        {
            await SeedUserRolesAsync(context);
        }

        
        #region SeedUserRolesAsync
        public static async Task SeedUserRolesAsync(AppIdentityDbContext context)
        {
            if (context.UserRoles.Any())
                return;

            var jsonData = await File.ReadAllTextAsync("../Infrastructure/Data/Seeds/Identity/StaticFiles/UserRoles.json");
            var data = JsonConvert.DeserializeObject<IdentityUserRole<string>>(jsonData);

            context.UserRoles.AddRange(data);
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
