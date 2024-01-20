using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Web.Extensions
{
    public static class DatabaseExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, string? ConnectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(
                    ConnectionString,
                    options => options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                    ));
        }
    }
}