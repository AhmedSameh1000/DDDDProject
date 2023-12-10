using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Seeds
{
    public static class SeedRoles
    {
        public static async Task Seed(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.Roles.AnyAsync())
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.Constants.UserRole));
                await roleManager.CreateAsync(new IdentityRole(Constants.Constants.AdminRole));
            }
        }
    }
}
