// <copyright file="OrderItemController.cs" company="Danieli Systec d.o.o.">
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
    /// <summary>Class for Order item controller.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController(DataContext context) : ControllerBase
    {
        private readonly DataContext context = context;

        /// <summary>Gets all order items.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<OrderItem>>> GetAllOrderItems()
        {
            var ordersItems = await this.context.OrderItems.Include(r => r.OrderId).Include(r => r.CustomerId).Include(r => r.ItemId).Where(r => r.IsActive).ToListAsync();
            return this.Ok(ordersItems);
        }

        /// <summary>Gets the order item.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
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

        /// <summary>Adds the order item.</summary>
        /// <param name="orderItem">The order item.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<List<OrderItem>>> AddOrderItem(OrderItem orderItem)
        {
            orderItem.CreatedDate = DateTime.UtcNow;
            orderItem.ModifiedDate = null;
            this.context.OrderItems.Add(orderItem);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(this.AddOrderItem), await this.context.Restaurants.ToListAsync());
        }

        /// <summary>Updates the order item.</summary>
        /// <param name="updatedOrderItem">The updated order item.</param>
        /// <returns>
        ///   <br />
        /// </returns>
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
