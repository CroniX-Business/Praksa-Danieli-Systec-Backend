// <copyright file="ItemController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.AspNetCore.Mvc;
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
        /// <summary>Gets all items.</summary>
        /// <returns>
        ///   Returns list of items.
        /// </returns>
        [HttpGet]
        public IActionResult GetAllItems()
        {
            var items = new List<Item>()
            {
                new Item()
                {
                    Id = 1,
                    Name = "Test",
                    Sort = 1,
                    Price = 1,
                    CategoryId = 1,
                },
            };

            return this.Ok(items);
        }
    }
}
