﻿using BlazorApp.Test.Data;
using Microsoft.AspNetCore.Identity;

namespace BlazorApp.Test.Codes;

public class RoleHandler
{
    public async Task CreateUserRoles(string user, string role, IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        var userRoleCheck = await roleManager.RoleExistsAsync(role);

        if (!userRoleCheck)
        {
            var roleObj = new IdentityRole(role);
            await roleManager.CreateAsync(roleObj);
        }
        ApplicationUser identityUser = await userManager.FindByEmailAsync(user);

        await userManager.AddToRoleAsync(identityUser, role);
    }
}
