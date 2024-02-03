﻿using Microsoft.AspNetCore.Identity;
using Infrastructure.Data.Contexts.Application;
using Core.Entities.UserIdentity;

namespace Web.Extensions
{
    public static class IdentityExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();
        }
    }
}