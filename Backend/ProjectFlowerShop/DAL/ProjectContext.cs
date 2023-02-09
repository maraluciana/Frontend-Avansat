using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.DAL
{
    public class ProjectContext : IdentityDbContext <User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }
        public DbSet<Discount> Discounts { get; set; } 
        public DbSet<ProductCart> ProductCart { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Letter> Letters { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //ProductCart
            modelBuilder.Entity<ProductCart>().HasKey(uc => new { uc.ProductId, uc.CartId });

            modelBuilder.Entity<ProductCart>()
                .HasOne(fb => fb.Product)
                .WithMany(f => f.ProductCarts)
                .HasForeignKey(fb => fb.ProductId);

            modelBuilder.Entity<ProductCart>()
                .HasOne(fb => fb.ShoppingCart)
                .WithMany(b => b.ProductCarts)
                .HasForeignKey(fb => fb.CartId);

            //ShoppingCart
            modelBuilder.Entity<ShoppingCart>()
                .HasOne(x => x.Letter)
                .WithOne(x => x.ShoppingCart);

            //Discount
            modelBuilder.Entity<Discount>()
                .HasMany(x => x.ShoppingCarts)
                .WithOne(x => x.Discount);
        }

    }
}
