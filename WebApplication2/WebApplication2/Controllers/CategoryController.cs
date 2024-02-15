// <copyright file="CategoryController.cs" company="Danieli Systec d.o.o.">
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
    ///   Represents a category controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        /// <summary>The context.</summary>
        private readonly DataContext context;

        /// <summary>Initializes a new instance of the <see cref="CategoryController" /> class.</summary>
        /// <param name="context">The context.</param>
        public CategoryController(DataContext context)
        {
            this.context = context;
        }

        /// <summary>Gets all categories.</summary>
        /// <returns>
        ///   Returns list of categories.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await this.context.Categories.ToListAsync();

            return this.Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Category>>> GetCategory(int id)
        {
            var category = await this.context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound("Category not found.");
            }

            return this.Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category category)
        {
            this.context.Categories.Add(category);
            await context.SaveChangesAsync();

            return this.Ok(await context.Categories.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Category>>> UpdateCategory(Category updatedCategory)
        {
            var dbCategory = await this.context.Categories.FindAsync(updatedCategory.Id);
            if (dbCategory == null)
            {
                return NotFound("Category not found.");
            }

            dbCategory.Id = updatedCategory.Id;
            dbCategory.Name = updatedCategory.Name;
            dbCategory.Sort = updatedCategory.Sort;
            dbCategory.RestaurantId = updatedCategory.RestaurantId;

            await context.SaveChangesAsync();

            return this.Ok(await context.Categories.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var dbCategory = await this.context.Categories.FindAsync(id);
            if (dbCategory == null)
            {
                return NotFound("Category not found.");
            }

            context.Categories.Remove(dbCategory);

            await context.SaveChangesAsync();

            return this.Ok(await context.Categories.ToListAsync());
        }
    }
}
