using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RestaurantController : ControllerBase
    {
        private readonly DataContext _context;

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "Restaurant1",
                    Address = "Pere Perica 1",
                    TelephoneNumber = "1234567890",
                }
            };
            return Ok(restaurants);
        }
    }
}
