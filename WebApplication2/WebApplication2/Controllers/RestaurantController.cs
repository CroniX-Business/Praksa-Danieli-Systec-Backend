using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RestaurantController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context =  context;

        [HttpGet]
        public async Task<ActionResult<Restaurant>> GetAllRestaurants()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<ActionResult<List<Restaurant>>> AddRestaurant(Restaurant restaurant)
        {
            restaurant.CreatedDate = DateTime.Now;
            restaurant.ModifiedDate = null;
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return Ok(await _context.Restaurants.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Restaurant>>> UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var restaurant = await _context.Restaurants.FindAsync(updatedRestaurant.Id);
            if(restaurant == null)
            {
                return NotFound();
            }
            restaurant.Name = updatedRestaurant.Name;
            restaurant.TelephoneNumber = updatedRestaurant.TelephoneNumber;
            restaurant.Address = updatedRestaurant.Address;
            return Ok(await _context.Restaurants.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<List<Restaurant>>> DeleteRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();

            return Ok(await _context.Restaurants.ToListAsync());
        }
    }

}
