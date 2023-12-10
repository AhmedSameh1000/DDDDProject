using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Seeds
{
    public class SeedAdmin
    {
        public static async Task Seed(UserManager<User> userManager)
        {
            if (!await userManager.Users.AnyAsync())
            {
                var User = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Ahmed",
                    LastName = "Sameh",
                    EmailConfirmed = true,
                    Email = "Admin@gmail.com",
                    UserName = "Admin@gmail.com"
                };
                var Result = await userManager.CreateAsync(User, "ahmeds1490");
                if (Result.Succeeded)
                {
                    await userManager.AddToRolesAsync(
                        User,
                        new List<string>
                        {
                            Constants.Constants.AdminRole,
                            Constants.Constants.UserRole
                        }
                    );
                }
            }
        }
    }
}
