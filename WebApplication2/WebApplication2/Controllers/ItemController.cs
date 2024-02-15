using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "Category1",
                    Sort = 1,
                    Price = 1.55m,
                    CategoryId = 1,
                }
            };
            return Ok(items);
        }
    }
}
