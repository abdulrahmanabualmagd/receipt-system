namespace MVC_Core.Extensions
{
    public static class RoutingExtension
    {
        public static void UseRoutes(this IEndpointRouteBuilder app)
        {
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Home}/{id?}");
        }
    }
}
