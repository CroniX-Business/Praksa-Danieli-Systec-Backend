using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Entities;

namespace WebApplication2.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options) { 
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOne<Restaurant>(c => c.Restaurant)
                .WithMany(r => r.Categories)
                .HasForeignKey(c => c.RestaurantId);

            modelBuilder.Entity<Item>()
                .HasOne<Category>(c => c.Category)
                .WithMany(r => r.Items)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<OrderItem>()
                .HasOne<Category>(c => c.Category)
                .WithMany(r => r.OrderItems)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<OrderItem>()
               .HasOne<Order>(c => c.Order)
               .WithMany(r => r.OrderItems)
               .HasForeignKey(c => c.OrderId);

            modelBuilder.Entity<User>()
                .HasOne<OrderItem>(s => s.OrderItem)
                .WithOne(r => r.User)
                .HasForeignKey<OrderItem>(s => s.UserId);
        }



    }
}
