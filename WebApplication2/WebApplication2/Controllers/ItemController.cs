// <copyright file="ItemController.cs" company="Danieli Systec d.o.o.">
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
    /// <summary>
    ///   Represents a item controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly DataContext context;

        /// <summary>Initializes a new instance of the <see cref="ItemController" /> class.</summary>
        /// <param name="context">The context.</param>
        public ItemController(DataContext context)
        {
            this.context = context;
        }

        /// <summary>Gets all items.</summary>
        /// <returns>
        ///   Returns list of items.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetAllItems()
        {
            var items = await this.context.Items.ToListAsync();

            return this.Ok(items);
        }

        /// <summary>Gets the item.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns item.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Item>>> GetItem(int id)
        {
            var item = await this.context.Items.FindAsync(id);
            if (item == null)
            {
                return this.NotFound("Item not found.");
            }

            return this.Ok(item);
        }

        /// <summary>Adds the item.</summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   Returns list of items.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<List<Item>>> AddItem(Item item)
        {
            this.context.Items.Add(item);
            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Items.ToListAsync());
        }

        /// <summary>Updates the item.</summary>
        /// <param name="updatedItem">The updated item.</param>
        /// <returns>
        ///   Returns list of items.
        /// </returns>
        [HttpPut]
        public async Task<ActionResult<List<Item>>> UpdateItem(Item updatedItem)
        {
            var dbItem = await this.context.Items.FindAsync(updatedItem.Id);
            if (dbItem == null)
            {
                return this.NotFound("Item not found.");
            }

            dbItem.Id = updatedItem.Id;
            dbItem.Name = updatedItem.Name;
            dbItem.Sort = updatedItem.Sort;
            dbItem.Price = updatedItem.Price;
            dbItem.CategoryId = updatedItem.CategoryId;

            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Items.ToListAsync());
        }

        /// <summary>Deletes the item.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns list of items.
        /// </returns>
        [HttpDelete]
        public async Task<ActionResult<List<Item>>> DeleteItem(int id)
        {
            var dbItem = await this.context.Items.FindAsync(id);
            if (dbItem == null)
            {
                return this.NotFound("Item not found.");
            }

            this.context.Items.Remove(dbItem);

            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Items.ToListAsync());
        }
    }
}

