using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
