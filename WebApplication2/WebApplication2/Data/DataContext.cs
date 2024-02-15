using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) :base (options) 
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
