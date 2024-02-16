using Microsoft.EntityFrameworkCore;
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



    }
}
