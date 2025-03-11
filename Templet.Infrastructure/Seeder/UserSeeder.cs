using Templet.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Templet.Infrastructure.Seeder;

public static class UserSeeder
{

    public static async Task SeedAsync(UserManager<Employee> userManager)
    {
        var users = await userManager.Users.CountAsync();
        if (users <= 0)
        {
            var defaultUser = new Employee
            {
                UserName = "admin",
                FirstName = "Admin AGECS Project",
                LastName = "DR Ehab",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                Password = "Admin@123",
                PhoneNumber = "123456789",
            };
            await userManager.CreateAsync(defaultUser, "Admin@123");
            await userManager.AddToRoleAsync(defaultUser, "Admin");
        }

    }
}