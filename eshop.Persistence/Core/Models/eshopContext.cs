using System;
using eshop.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eshop.Persistence.Core.Models
{
    //public partial class eshopContext : DbContext
    public partial class eshopContext : IdentityDbContext<Customer>
    {
        public eshopContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }


        public virtual DbSet<Product> Products { get; set; }


        public virtual DbSet<Category> Categories { get; set; }


        public virtual DbSet<OrderItem> OrderItems { get; set; }


        public virtual DbSet<Order> Orders { get; set; }

                
        public virtual DbSet<Shipping> Shipping { get; set; }


        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*
            builder.Entity<Category>().HasData(new Category[]
            {
                new Category{ Id = 1, Name = "Bread" },
                new Category{ Id = 2, Name = "Dairy" },
                new Category{ Id = 3, Name = "Fruits" },
                new Category{ Id = 4, Name = "Seasonings and Spices" },
                new Category{ Id = 5, Name = "Vegetables" }
            });
            */

            builder.ApplyConfiguration(new AppUserConfiguration());

            
            base.OnModelCreating(builder);
        }
    }
}
