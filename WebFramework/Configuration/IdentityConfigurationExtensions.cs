﻿using Microsoft.Extensions.DependencyInjection;
using Entities;
using Common;
using Microsoft.AspNetCore.Identity;
using Data;
using Entities.User;
using Entities.Role;

namespace infrastructure.WebFramework.Configuration
{
    public static class IdentityConfigurationExtensions
    {
        public static void AddCustomIdentity(this IServiceCollection services, IdentitySettings settings)
        {
            services.AddIdentityCore<User>()
                .AddRoles<Role>().AddSignInManager<SignInManager<User>>()
                .AddUserManager<UserManager<User>>().AddEntityFrameworkStores<ApplicationDbContext>();
        }

    }
}
