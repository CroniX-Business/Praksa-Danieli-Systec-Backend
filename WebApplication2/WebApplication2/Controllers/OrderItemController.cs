using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController(DataContext context) : ControllerBase
    {
        private readonly DataContext context = context;

        [HttpGet]
        public async Task<ActionResult<List<OrderItem>>> GetAllOrderItems()
        {
            var ordersItems = await this.context.OrderItems.Include(r => r.OrderId).Include(r => r.CustomerId).Include(r => r.ItemId).Where(r => r.IsActive).ToListAsync();
            return this.Ok(ordersItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<OrderItem>>> GetOrderItem(int id)
        {
            var orderItem = await this.context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return this.NotFound("OrderItem not found.");
            }

            return this.Ok(orderItem);
        }

        [HttpPost]
        public async Task<ActionResult<List<OrderItem>>> AddOrderItem(OrderItem orderItem)
        {
            orderItem.CreatedDate = DateTime.UtcNow;
            orderItem.ModifiedDate = null;
            this.context.OrderItems.Add(orderItem);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(this.AddOrderItem), await this.context.Restaurants.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Order>>> UpdateOrderItem(OrderItem updatedOrderItem)
        {
            var dbOrderItem = await this.context.OrderItems.FindAsync(updatedOrderItem.Id);
            if (dbOrderItem is null)
            {
                return this.NotFound("OrderItem not found");
            }

            dbOrderItem.ModifiedDate = DateTime.UtcNow;
            dbOrderItem.Name = updatedOrderItem.Name;
            dbOrderItem.Price = updatedOrderItem.Price;
            dbOrderItem.ItemId = updatedOrderItem.ItemId;
            dbOrderItem.Quantity = updatedOrderItem.Quantity;
            dbOrderItem.OrderId = updatedOrderItem.OrderId;
            dbOrderItem.CustomerId = updatedOrderItem.CustomerId;

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
