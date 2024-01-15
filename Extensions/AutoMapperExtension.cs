using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVC_Core.Mappings;

namespace MVC_Core.Extensions
{
    public static class AutoMapperExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}
