// <copyright file="ItemController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersApi.Data;
using OrdersApi.Dto;
using OrdersApi.Entities;

namespace OrdersApi.Controllers
{
    /// <summary>Represents a item controller.</summary>
    /// <remarks>Initializes a new instance of the <see cref="ItemController" /> class.</remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(DataContext context, IMapper mapper, ILogger<ItemController> logger) : ControllerBase
    {
        private readonly DataContext context = context;

        private readonly IMapper mapper = mapper;

        private readonly ILogger<ItemController> logger = logger;

        /// <summary>Gets all items.</summary>
        /// <returns>Returns list of items.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllItems()
        {
            try
            {
                var items = await this.context.Items.Where(i => i.IsActive).ToListAsync();

                this.logger.LogDebug("Retrieved {Count} items successfully.", items.Count);

                return this.Ok(items.Select(this.mapper.Map<ItemDto>));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while retrieving items.");
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Gets the item.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns item.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItem(int id)
        {
            try
            {
                var item = await this.context.Items.FirstOrDefaultAsync(i => i.Id == id && i.IsActive);

                if (item == null)
                {
                    this.logger.LogWarning("Item with ID {Id} not found.", id);

                    return this.NotFound();
                }

                this.logger.LogDebug("Retrieved item with ID {Id} successfully.", id);
                return this.Ok(this.mapper.Map<ItemDto>(item));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while retrieving item with ID {Id}.", id);
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Adds the item.</summary>
        /// <param name="newItem">The new item.</param>
        /// <returns>Returns list of items.</returns>
        [HttpPost]
        public async Task<ActionResult<ItemDto>> AddItem(ItemDto newItem)
        {
            try
            {
                var item = this.mapper.Map<Item>(newItem);
                this.context.Items.Add(item);
                await this.context.SaveChangesAsync();

                this.logger.LogDebug("Item added successfully: {@item}.", item);

                return this.CreatedAtAction(
                    nameof(this.AddItem),
                    this.mapper.Map<ItemDto>(item));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while adding a new item: {@NewItem}.", newItem);
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Updates the item.</summary>
        /// <param name="updatedItem">The updated item.</param>
        /// <param name="id">Id of item.</param>
        /// <returns>Returns list of items.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDto>> UpdateItem(ItemDto updatedItem, int id)
        {
            try
            {
                var dbItem = await this.context.Items.FirstOrDefaultAsync(r => r.Id == id);

                if (dbItem == null)
                {
                    this.logger.LogWarning("Item with ID {Id} not found while updating.", id);
                    return this.NotFound();
                }

                this.mapper.Map(updatedItem, dbItem);

                await this.context.SaveChangesAsync();

                this.logger.LogDebug("Item with ID {Id} updated successfully.", id);
                return this.NoContent();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while updating item with ID {Id}.", id);
                return this.StatusCode(500, "Error occurred while processing your request.");
            }
        }

        /// <summary>Deletes the item.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns list of items.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            try
            {
                var dbItem = await this.context.Items.FirstOrDefaultAsync(c => c.Id == id && c.IsActive);

                if (dbItem == null)
                {
                    this.logger.LogWarning("Item with ID {Id} not found while deleting.", id);
                    return this.NotFound();
                }

                dbItem.IsActive = false;
                await this.context.SaveChangesAsync();

                this.logger.LogDebug("Item with ID {Id} deleted successfully.", id);

                return this.NoContent();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while deleting item with ID {Id}.", id);
                return this.StatusCode(500, "Error occurred while processing your request");
            }
        }
    }
}
