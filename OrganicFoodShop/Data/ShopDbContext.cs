
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using OrganicFoodShop.Data.Models;

namespace OrganicFoodShop.Data
{
    public class ShopDbContext : IdentityDbContext //   <User>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)   
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<Product>()
               .HasOne(p => p.Employee)
               .WithMany(e => e.Products)
               .HasForeignKey(p => p.EmployeeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Employee>()
                //.HasOne<User>()
                .HasOne<IdentityUser>()
                .WithOne()
                .HasForeignKey<Employee>(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
