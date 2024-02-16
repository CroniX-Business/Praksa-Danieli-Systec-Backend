// <copyright file="CategoryController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>
/*
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    /// <summary>
    ///   Represents a category controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        /// <summary>Gets all categories.</summary>
        /// <returns>
        ///   Returns list of categories.
        /// </returns>
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = new List<Category>()
            {
                new()
                {
                    Id = 1,
                    Name = "Test",
                    Sort = 1,
                    RestaurantId = 1,
                },
            };

            return this.Ok(categories);
        }
    }
}
*/