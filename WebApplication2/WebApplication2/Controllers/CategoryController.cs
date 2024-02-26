// <copyright file="CategoryController.cs" company="Danieli Systec d.o.o.">
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
    ///   Represents a category controller.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="CategoryController" /> class.</remarks>
    /// <param name="context">The context.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMapper mapper, DataContext context) : ControllerBase
    {
        /// <summary>The context.</summary>
        private readonly DataContext context = context;

        private readonly IMapper mapper = mapper;

        /// <summary>Gets all categories.</summary>
        /// <returns>
        ///   Returns list of categories.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
        {
            var categories = await this.context.Categories.Where(c => c.IsActive).ToListAsync();

            return this.Ok(categories.Select(this.mapper.Map<CategoryDTO>));
        }

        /// <summary>
        ///   <para>
        /// Gets the category.
        /// </para>
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///  Returns category.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var category = await this.context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null || !category.IsActive)
            {
                return this.NotFound("Category not found.");
            }

            return this.Ok(this.mapper.Map<CategoryDTO>(category));
        }

        /// <summary>Adds the category.</summary>
        /// <param name="newCategory">The new category.</param>
        /// <returns>
        ///   Returns category.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> AddCategory(CategoryDTO newCategory)
        {
            var category = this.mapper.Map<Category>(newCategory);
            this.context.Categories.Add(category);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(this.AddCategory), this.mapper.Map<CategoryDTO>(category));
        }

        /// <summary>Updates the category.</summary>
        /// <param name="updatedCategory">The updated category.</param>
        /// <param name="id">The indentifier of category we change.</param>
        /// <returns>Returns list of categories.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(CategoryDTO updatedCategory, int id)
        {
            var dbCategory = await this.context.Categories.FirstOrDefaultAsync(r => r.Id == id);
            if (dbCategory == null)
            {
                return this.NotFound("Category not found.");
            }

            updatedCategory.CreatedDate = dbCategory.CreatedDate;

            this.mapper.Map(updatedCategory, dbCategory);

            await this.context.SaveChangesAsync();

            return this.NoContent();
        }

        /// <summary>Deletes the category.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///  Returns list of categories.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var dbCategory = await this.context.Categories.FirstOrDefaultAsync(r => r.Id == id);
            if (dbCategory == null)
            {
                return this.NotFound("Category not found.");
            }

            dbCategory.IsActive = false;
            dbCategory.ModifiedDate = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return this.NoContent();
        }
    }
}