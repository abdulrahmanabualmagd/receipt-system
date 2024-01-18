using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

namespace MVC_Core.Extensions
{
    public static class AuthenticationExtension
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie()
                .AddGoogle(GoogleDefaults.AuthenticationScheme ,options =>
                {
                    options.ClientId = configuration["ClientId"];
                    options.ClientSecret = configuration["ClientSecret"];
                    options.CallbackPath = new PathString("/signin-google");
                    #region Scopes
                    //options.Scope.Add("openid");
                    //options.Scope.Add("profile");
                    //options.Scope.Add("email");
                    //options.Scope.Add("https://www.googleapis.com/auth/userinfo.profile"); 
                    #endregion
                })

                //.AddOAuth("github", options =>
                //{
                //    options.ClientId = "";
                //    options.ClientSecret = "";

                //    options.AuthorizationEndpoint = "";
                //    options.TokenEndpoint = "";

                //    options.UserInformationEndpoint = "";
                //})

                //.AddFacebook(options =>
                //{
                //    options.ClientId = "";
                //    options.ClientSecret = "";
                //})
                ;
        }
    }
}
