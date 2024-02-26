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
                    options.ClientId = configuration["Authentication:Google:ClientID"] ?? "write something";
                    options.ClientSecret = configuration["Authentication:Google:ClientSecret"] ?? "write something";
                    options.CallbackPath = new PathString("/signin-google");
                })

                .AddFacebook(FacebookDefaults.AuthenticationScheme ,options =>
                {
                    options.ClientId = configuration["Authentication:Facebook:ClientID"] ?? "write something";
                    options.ClientSecret = configuration["Authentication:Facebook:ClientSecret"] ?? "write something";

                })

                .AddOAuth("GitHub", options =>
                {
                    options.ClientId = configuration["Authentication:GitHub:ClientID"] ?? "write something";
                    options.ClientSecret = configuration["Authentication:GitHub:ClientSecret"] ?? "write something";

                    options.CallbackPath = "/signin-oauth";

                    options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
                    options.TokenEndpoint = "https://github.com/login/oauth/access_token";
                    options.UserInformationEndpoint = "https://api.github.com/user";
                });


        }
    }
}
