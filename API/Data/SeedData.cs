using System.Text.Json;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public static class SeedData
{
  public static async Task SeedUsersAsync(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
  {
    if (await userManager.Users.AnyAsync()) return; // checks if there is any record in the db and then if any stops populating  the db if not populates the db with the seed data that we have.
    var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
    var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

    // if (users == null) return; or
    if (users is null) return;

    var roles = new List<AppRole>{
            new AppRole{Name = RolePermission.Admin},
            new AppRole{Name = RolePermission.Member},
            new AppRole{Name = RolePermission.Moderator}
        };
    foreach (var role in roles)
    {
      await roleManager.CreateAsync(role);
    }
    foreach (var user in users)
    {
      user.UserName = user.UserName.ToLower();
      await userManager.CreateAsync(user, "P@ssw0rd");
      await userManager.AddToRoleAsync(user, RolePermission.Member);
    }
    var adminUser = new AppUser
    {
      UserName = "admin",
      Firstname = "Ignatius",
      Lastname = "Omeje",
      Gender = "male",
      Email= "admin@gmail.com",
    };
    await userManager.CreateAsync(adminUser, "P@ssw0rd");
    await userManager.AddToRolesAsync(adminUser, new[] {
            RolePermission.Admin, RolePermission.Moderator
        });
  }
}