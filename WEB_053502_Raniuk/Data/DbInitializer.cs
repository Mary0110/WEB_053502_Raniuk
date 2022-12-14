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
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public DbInitializer(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async void Initialize()
    {
        if (!_context.Users.Any())

        {
            //create database schema if none exists
            await _context.Database.EnsureCreatedAsync();

            await _roleManager.CreateAsync(new IdentityRole("admin"));
            await _roleManager.CreateAsync(new IdentityRole("user"));

            //Create the default Admin & User accounts
            string password = "rootpass";

            var admin = new ApplicationUser
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
            }

            await _context.SaveChangesAsync();
        }
        
        if (!_context.Films.Any())
        {
             var film2 = new Film
            {
                Id = 2,
                Name = "GOT",
                Description = "jsdn j",
                Category = "Series",
                CategoryId = 2,
                Duration = 2,
                Image = "got.jpg"
            };

            var film1 = new Film
            {
                Id = 1,
                Name = "Breaking bad",
                Description = "jsdn j",
                Category = "Series",
                CategoryId = 2,
                Duration = 1,
                Image= "breaking_bad.jpeg"
            };

            var film3 = new Film
            {
                Id = 3,
                Name = "The Sopranos",
                Description = "jsdn j",
                Category = "Series",
                CategoryId = 2,
                Duration = 3,
                Image = "the_sopranos.jpg"
            };

            var film4 = new Film
            {
                Id = 4,
                Name = "House of cards",
                Description = "jsdn j",
                Category = "Series",
                CategoryId = 2,
                Duration = 4,
                Image = "house_of_cards.jpg"
            };
            
            var film5 = new Film
            {
                Id = 5,
                Name = "Braveheart",
                Description = "jsdn j",
                Category = "Films",
                CategoryId = 1,
                Duration = 5,
                Image = "braveheart.jpg"
            };
           
            await _context.Films.AddAsync(film1);
            await _context.Films.AddAsync(film2);
            await _context.Films.AddAsync(film3);
            await _context.Films.AddAsync(film4);
            await _context.Films.AddAsync(film5);

            await _context.SaveChangesAsync();
        }

        if (!_context.Categories.Any())
        {


            var cat1 = new Category {  CategoryName = "Films" };
            var cat2 = new Category {  CategoryName = "Series" };
            
            await _context.Categories.AddAsync(cat1);
            await _context.Categories.AddAsync(cat2);
            
            await _context.SaveChangesAsync();

        }

    }
}
