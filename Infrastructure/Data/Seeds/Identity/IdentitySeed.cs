using Core.Entities.UserIdentity;
using Infrastructure.Data.Contexts.Identity;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Infrastructure.Data.Seeds.Identity
{
    public static class IdentitySeed
    {
        public static async Task SeedIdentityAsync(AppIdentityDbContext context)
        {
            await SeedUsersDataAsync(context);
            await SeedRolesDataAsync(context);
            await SeedUserRolesAsync(context);
        }

        #region SeedUsersDataAsync
        public static async Task SeedUsersDataAsync(AppIdentityDbContext context)
        {
            if (context.Users.Any())
                return;

            var jsonData = await File.ReadAllTextAsync("../Infrastructure/Data/Seeds/Identity/StaticFiles/ApplicationUsers.json");
            var data = JsonConvert.DeserializeObject<List<ApplicationUser>>(jsonData);

            context.Users.AddRange(data);
            await context.SaveChangesAsync();
        }
        #endregion

        #region SeedRolesDataAsync
        public static async Task SeedRolesDataAsync(AppIdentityDbContext context)
        {
            if (context.Roles.Any())
                return;

            var jsonData = await File.ReadAllTextAsync("../Infrastructure/Data/Seeds/Identity/StaticFiles/Roles.json");
            var data = JsonConvert.DeserializeObject<IdentityRole>(jsonData);

            context.Roles.AddRange(data);
            await context.SaveChangesAsync();
        }
        #endregion

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
