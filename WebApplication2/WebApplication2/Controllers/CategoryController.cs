using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController (DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpGet]
        public async Task<ActionResult<Category>> GetAllCategories()
        {
            var categories = await _context.Category.ToListAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return Ok(await _context.Category.ToListAsync());
        }

    }
}
