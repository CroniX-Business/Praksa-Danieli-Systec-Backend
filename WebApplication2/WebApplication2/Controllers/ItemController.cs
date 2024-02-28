// <copyright file="ItemController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    /// <summary>
    ///   Represents a item controller.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="ItemController" /> class.</remarks>
    /// <param name="context">The context.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IMapper mapper, DataContext context, ILogger<ItemController> logger) : ControllerBase
    {
        private readonly DataContext context = context;

        private readonly IMapper mapper = mapper;

        private readonly ILogger<ItemController> logger = logger;

        /// <summary>Gets all items.</summary>
        /// <returns>
        ///   Returns list of items.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetAllItems()
        {
            try
            {
                var items = await this.context.Items.Where(r => r.IsActive).ToListAsync();

                this.logger.LogDebug("Retrieved {Count} items successfully.", items.Count);

                return this.Ok(items.Select(this.mapper.Map<ItemDTO>));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while retrieving items.");
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Gets the item.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns item.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItem(int id)
        {
            try
            {
                var item = await this.context.Items.FirstOrDefaultAsync(r => r.Id == id);
                if (item is null || !item.IsActive)
                {
                    this.logger.LogWarning("Item with ID {Id} not found.", id);

                    return this.NotFound();
                }

                this.logger.LogDebug("Retrieved item with ID {Id} successfully.", id);
                return this.Ok(this.mapper.Map<ItemDTO>(item));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while retrieving item with ID {Id}.", id);
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Adds the item.</summary>
        /// <param name="newItem">The item.</param>
        /// <returns>
        ///   Returns list of items.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<ItemDTO>> AddItem(ItemDTO newItem)
        {
            try
            {
                var item = this.mapper.Map<Item>(newItem);
                this.context.Items.Add(item);
                await this.context.SaveChangesAsync();

                this.logger.LogDebug("Item added successfully: {@item}.", item);

                return this.CreatedAtAction(nameof(this.AddItem), this.mapper.Map<ItemDTO>(item));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while adding a new newItem: {@newItem}.", newItem);
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Updates the item.</summary>
        /// <param name="id">The identifier of item we change.</param>
        /// <param name="updatedItem">The updated item.</param>
        /// <returns>
        ///  Returns list of items.
        /// </returns>
        [HttpPut]
        public async Task<ActionResult<ItemDTO>> UpdateItem(int id, ItemDTO updatedItem)
        {
            try
            {
                var dbItem = await this.context.Items.FirstOrDefaultAsync(r => r.Id == id);
                if (dbItem is null)
                {
                    this.logger.LogWarning("Item with ID {Id} not found while updating.", id);
                    return this.NotFound();
                }

                dbItem = this.mapper.Map(updatedItem, dbItem);

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
        /// <returns>
        ///   Returns list of items.
        /// </returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteItem(int id)
        {
            try
            {
                var dbItem = await this.context.Items.FindAsync(id);
                if (dbItem is null)
                {
                    this.logger.LogWarning("Item with ID {Id} not found while deleting.", id);
                    return this.NotFound();
                }

                dbItem.IsActive = false;
                dbItem.ModifiedDate = DateTime.UtcNow;
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
