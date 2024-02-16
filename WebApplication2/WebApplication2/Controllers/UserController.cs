using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            var users = await _context.User.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
