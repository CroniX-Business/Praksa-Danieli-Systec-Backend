// <copyright file="OrderController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    /// <summary>Order controller class.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(DataContext context) : ControllerBase
    {
        private readonly DataContext context = context;

        /// <summary>Gets all orders.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var orders = await this.context.Orders.Include(r => r.OrderItems).Where(r => r.IsActive).ToListAsync();
            return this.Ok(orders);
        }

        /// <summary>Gets the order.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
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

        /// <summary>Adds the order.</summary>
        /// <param name="order">The order.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<List<Order>>> AddOrder(Order order)
        {
            order.CreatedDate = DateTime.UtcNow;
            order.ModifiedDate = null;
            this.context.Orders.Add(order);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(this.AddOrder), await this.context.Restaurants.ToListAsync());
        }

        /// <summary>Updates the order.</summary>
        /// <param name="updatedOrder">The updated order.</param>
        /// <returns>
        ///   <br />
        /// </returns>
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

        /// <summary>Deletes the order.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
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
