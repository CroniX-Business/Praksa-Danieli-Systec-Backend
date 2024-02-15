using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "User",
                    LastName = "Useric1",
                    Telephone = "091564678",
                }
            };
            return Ok(users);
        }
    }
}
