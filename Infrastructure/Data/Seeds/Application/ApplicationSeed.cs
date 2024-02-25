/*
 * Upcoming Modification 
 *  - Simplify the methods make a generic method and use Set<T>() like in Generic repository
 */
using Core.Entities;
using Core.Entities.Application;
using Infrastructure.Data.Contexts.Application;
using Newtonsoft.Json;
using System.Net;

namespace Infrastructure.Data.Seeds.Application
{
    public static class ApplicationSeed
    {
        public static async Task SeedEntityAsync(ApplicationDbContext context)
        {
            await SeedData<Category>(context, "Categories");
            await SeedData<Item>(context, "Items");
        }

        public static async Task SeedData<T>(ApplicationDbContext context, string entityName) where T : class 
        {
            if (context.Set<T>().Any())
                return;

            string path = $"../Infrastructure/Data/Seeds/Application/StaticFiles/{entityName}.json";

           var jsonData = await File.ReadAllTextAsync(path);
            var data = JsonConvert.DeserializeObject<List<T>>(jsonData);

            context.Set<T>().AddRange(data);

            await context.SaveChangesAsync();
        }

    }
}
