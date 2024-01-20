namespace Web.Extensions
{
    public static class DefaultMiddlewareExtension
    {
        public static void UseDefaultMiddleware(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
