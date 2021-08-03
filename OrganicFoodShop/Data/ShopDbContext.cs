using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using OrganicFoodShop.Data.Models;

namespace OrganicFoodShop.Data
{
    public class ShopDbContext : IdentityDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }

      //  public DbSet<Category> Categories { get; init; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder
        //        .Entity<Product>()
        //        .HasOne(p => p.Category)
        //        .WithMany(c => c.Products)
        //        .HasForeignKey(p => p.CategoryId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    base.OnModelCreating(builder);
        //}
    }
}
