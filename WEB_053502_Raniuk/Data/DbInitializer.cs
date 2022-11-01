using Microsoft.AspNetCore.Identity;
using WEB_053502_Raniuk.Entities;

namespace WEB_053502_Raniuk.Data;

public interface IDbInitializer
{
    void Initialize();
}

public class DbInitializer : IDbInitializer
{
    private readonly ApplicationDbContext _context;
    /*private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;*/

    public DbInitializer(
        ApplicationDbContext context/*,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager*/)
    {
        _context = context;
        /*_userManager = userManager;
        _roleManager = roleManager;*/
    }

    public async void Initialize()
    {
        //if (_context.Users.Any()) return;

        //create database schema if none exists
        //await _context.Database.EnsureCreatedAsync();

        /*await _roleManager.CreateAsync(new IdentityRole("admin"));
        await _roleManager.CreateAsync(new IdentityRole("user"));*/

        //Create the default Admin & User accounts
        string password = "rootpass";

       /* var admin = new ApplicationUser
        {
            UserName = "root",
            Email = "root@mail.com",
            EmailConfirmed = false
        };
        var user = new ApplicationUser
        {
            UserName = "user",
            Email = "user@mail.com",
            EmailConfirmed = false
        };

        var res1 = await _userManager.CreateAsync(admin, password);
        var res2 = await _userManager.CreateAsync(user, password);

        if (res1.Succeeded)
        {
            await _userManager.AddToRoleAsync(admin, "admin");
        }

        if (res2.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "user");
        }*/

        //await _context.SaveChangesAsync();
    }
}
