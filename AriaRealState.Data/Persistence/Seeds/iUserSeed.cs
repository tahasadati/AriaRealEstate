using AriaRealState.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Persistence.Seeds;

public static class iUserSeed
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<iUser>>();

        var superAdminEmail = "superadmin@light.com";
        var existsingUser = await userManager.FindByEmailAsync(superAdminEmail);

        if (existsingUser == null)
        {
            var user = new iUser
            {
                FullName = "Super Admin",
                RegisterDate = DateTime.Now,
                UserImage = "png",
                UserName = "superadmin@light.com",
                Email = superAdminEmail,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var result = await userManager.CreateAsync(user, "QAZqaz!@#123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "SuperAdmin");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Failed to create SuperAdmin:");
                foreach (var err in result.Errors)
                    Console.WriteLine($"   - {err.Description}");
                Console.ResetColor();
            }
        }
        else
        {
            Console.WriteLine("ℹ️ SuperAdmin already exists, skipping seed...");
        }


        //======================================================================


        var supportEmail = "support@light.com";
        var existingSupportUser = await userManager.FindByEmailAsync(supportEmail);

        if (existingSupportUser == null)
        {
            var supportUser = new iUser
            {
                FullName = "Support Light",
                RegisterDate = DateTime.Now,
                UserImage = "png",
                UserName = "support@light.com",
                Email = supportEmail,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var result = await userManager.CreateAsync(supportUser, "QAZqaz!@#123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(supportUser, "SupportLight");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Failed to create SupportLight:");
                foreach (var err in result.Errors)
                    Console.WriteLine($"   - {err.Description}");
                Console.ResetColor();
            }
        }
        else
        {
            Console.WriteLine("ℹ️ SupportLight already exists, skipping seed...");
        }
    }
}