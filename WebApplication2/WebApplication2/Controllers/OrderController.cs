using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(DataContext context) : ControllerBase
    {
        private readonly DataContext context = context;

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var orders = await this.context.Orders.Include(r => r.OrderItems).Where(r => r.IsActive).ToListAsync();
            return this.Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Order>>> GetOrder(int id)
        {
            var order = await this.context.Orders.FindAsync(id);
            if (order == null)
            {
                return this.NotFound("Order not found.");
            }

            return this.Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<List<Order>>> AddOrder(Order order)
        {
            order.CreatedDate = DateTime.UtcNow;
            order.ModifiedDate = null;
            this.context.Orders.Add(order);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(this.AddOrder), await this.context.Restaurants.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Order>>> UpdateOrder(Order updatedOrder)
        {
            var dbOrder = await this.context.Orders.FindAsync(updatedOrder.Id);
            if (dbOrder is null)
            {
                return this.NotFound("Order not found");
            }

            dbOrder.ModifiedDate = DateTime.UtcNow;
            dbOrder.Name = updatedOrder.Name;
            dbOrder.IsOpen = updatedOrder.IsOpen;
            dbOrder.DateOfOrder = updatedOrder.DateOfOrder;

            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Restaurants.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Order>>> DeleteOrder(int id)
        {
            var dbOrder = await this.context.Orders.FindAsync(id);
            if (dbOrder is null)
            {
                return this.NotFound("Order not found");
            }

            dbOrder.ModifiedDate = DateTime.UtcNow;

            dbOrder.IsActive = false;

            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Restaurants.ToListAsync());
        }
    }
}
