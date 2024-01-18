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
                    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                })
                .AddCookie()
                .AddGoogle(GoogleDefaults.AuthenticationScheme ,options =>
                {
                    options.ClientId = configuration["Authentication:Google:ClientId"] ?? "N/A";
                    options.ClientSecret = configuration["Authentication:Google:ClientSecret"] ?? "N/A";
                    options.CallbackPath = new PathString("/signin-google");
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("email");
                    options.Scope.Add("https://www.googleapis.com/auth/userinfo.profile");
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
