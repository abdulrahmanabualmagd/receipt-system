using Microsoft.AspNetCore.Authentication;

namespace MVC_Core.Extensions
{
    public static class MapGetExtension
    {
        // Handler
        public static void UseMapGet(this IEndpointRouteBuilder app)
        {
            app.MapGet("/hello", context => context.Response.WriteAsync("Hello, World!"));
        }
    }
}
