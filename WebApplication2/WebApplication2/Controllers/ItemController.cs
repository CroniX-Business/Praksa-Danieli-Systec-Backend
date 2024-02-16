using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController (DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpGet]
        public async Task<ActionResult<Item>> GetAllItems()
        {
            var items = await _context.Item.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Item.FindAsync();

            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
