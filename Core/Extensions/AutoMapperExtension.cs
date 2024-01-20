using Microsoft.CodeAnalysis.CSharp.Syntax;
using Web.Mappings;

namespace Web.Extensions
{
    public static class AutoMapperExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}
