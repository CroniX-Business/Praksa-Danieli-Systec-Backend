// <copyright file="ItemController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    /// <summary>Item controller class.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(DataContext context) : ControllerBase
    {
        private readonly DataContext context = context;

        /// <summary>Gets all items.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<Item>> GetAllItems()
        {
            var items = await this.context.Item.ToListAsync();
            return this.Ok(items);
        }

        /// <summary>Gets the item.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await this.context.Item.FindAsync();

            if (item == null)
            {
                return this.NotFound();
            }

            return this.Ok(item);
        }
    }
}
