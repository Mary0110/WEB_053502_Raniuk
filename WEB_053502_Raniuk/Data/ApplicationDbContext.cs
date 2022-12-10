using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEB_053502_Raniuk.Entities;

namespace WEB_053502_Raniuk.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public new DbSet<ApplicationUser> Users { get; set; }
        
        public new DbSet<Film> Films { get; set; }
        public new DbSet<Category> Categories { get; set; }
        
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<Film>().ToTable("Film");
            base.OnModelCreating(modelBuilder);
        }*/
        
        

    }
}