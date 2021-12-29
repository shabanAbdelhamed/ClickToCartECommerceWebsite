
using CickToCart.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class ContextDataBase : IdentityDbContext<AppUser>
    {
        
        public ContextDataBase(DbContextOptions<ContextDataBase> options) : base(options)
        {

        }
        public DbSet<Product>Products { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<OrderStatus> OrdersStatuses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderdetails { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Shipping> shippings { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product_color> Product_Colors { get; set; }
        public DbSet<Product_Rating> Product_Ratings { get; set; }
        public DbSet<Product_Size> Product_Sizes { get; set; }
        public DbSet<Personalinfo> Personalinfos { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TagEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ColorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PersonalinfoEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
