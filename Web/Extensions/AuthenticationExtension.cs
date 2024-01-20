using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;

namespace Web.Extensions
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
                .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
                {
                    options.ClientId = configuration["Authentication:Google:ClientID"] ?? "";
                    options.ClientSecret = configuration["Authentication:Google:ClientSecret"] ?? "";
                    options.CallbackPath = new PathString("/signin-google");
                })

                .AddFacebook(FacebookDefaults.AuthenticationScheme ,options =>
                {
                    options.ClientId = configuration["Authentication:Facebook:ClientID"] ?? "";
                    options.ClientSecret = configuration["Authentication:Facebook:ClientSecret"] ?? "";

                })

                .AddOAuth("GitHub", options =>
                {
                    options.ClientId = configuration["Authentication:GitHub:ClientID"] ?? "";
                    options.ClientSecret = configuration["Authentication:GitHub:ClientSecret"] ?? "";

                    options.CallbackPath = "/signin-oauth";

                    options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
                    options.TokenEndpoint = "https://github.com/login/oauth/access_token";
                    options.UserInformationEndpoint = "https://api.github.com/user";
                });


        }
    }
}
