﻿// <copyright file="CategoryController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersApi.Data;
using OrdersApi.DTO;
using OrdersApi.Entities;

namespace OrdersApi.Controllers
{
    /// <summary>
    ///   Represents a category controller.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="CategoryController" /> class.</remarks>
    /// <param name="context">The context.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMapper mapper, DataContext context, ILogger<CategoryController> logger) : ControllerBase
    {
        /// <summary>The context.</summary>
        private readonly DataContext context = context;

        private readonly IMapper mapper = mapper;

        private readonly ILogger<CategoryController> logger = logger;

        /// <summary>Gets all categories.</summary>
        /// <returns>
        ///   Returns list of categories.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
        {
            try
            {
                var categories = await this.context.Categories.Where(r => r.IsActive).ToListAsync();

                this.logger.LogDebug("Retrieved {Count} categories successfully.", categories.Count);

                return this.Ok(categories.Select(this.mapper.Map<CategoryDTO>));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while retrieving categories.");
                return this.StatusCode(500, "Error occurred while processing request.");
            }
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
            try
            {
                var category = await this.context.Categories.FirstOrDefaultAsync(r => r.Id == id);
                if (category is null || !category.IsActive)
                {
                    this.logger.LogWarning("Category with ID {Id} not found.", id);

                    return this.NotFound();
                }

                this.logger.LogDebug("Retrieved category with ID {Id} successfully.", id);
                return this.Ok(this.mapper.Map<CategoryDTO>(category));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while retrieving category with ID {Id}.", id);
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Adds the category.</summary>
        /// <param name="newCategory">The new category.</param>
        /// <returns>
        ///   Returns category.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> AddCategory(CategoryDTO newCategory)
        {
            try
            {
                var category = this.mapper.Map<Category>(newCategory);
                this.context.Categories.Add(category);
                await this.context.SaveChangesAsync();

                this.logger.LogDebug("Category added successfully: {@category}.", category);

                return this.CreatedAtAction(nameof(this.AddCategory), this.mapper.Map<CategoryDTO>(category));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while adding a new category: {@NewCategory}.", newCategory);
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Updates the category.</summary>
        /// /// <param name="id">The identifier of category we change.</param>
        /// <param name="updatedCategory">The updated category.</param>
        /// <returns>Returns list of categories.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(int id, CategoryDTO updatedCategory)
        {
            try
            {
                var dbCategory = await this.context.Categories.FirstOrDefaultAsync(r => r.Id == id);
                if (dbCategory is null)
                {
                    this.logger.LogWarning("Category with ID {Id} not found while updating.", id);
                    return this.NotFound();
                }

                dbCategory = this.mapper.Map(updatedCategory, dbCategory);

                await this.context.SaveChangesAsync();

                this.logger.LogDebug("Category with ID {Id} updated successfully.", id);
                return this.NoContent();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while updating category with ID {Id}.", id);
                return this.StatusCode(500, "Error occurred while processing your request.");
            }
        }

        /// <summary>Deletes the category.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///  Returns list of categories.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                var dbCategory = await this.context.Categories.FindAsync(id);
                if (dbCategory is null)
                {
                    this.logger.LogWarning("Category with ID {Id} not found while deleting.", id);
                    return this.NotFound();
                }

                dbCategory.IsActive = false;
                await this.context.SaveChangesAsync();

                this.logger.LogDebug("Category with ID {Id} deleted successfully.", id);
                return this.NoContent();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while deleting category with ID {Id}.", id);
                return this.StatusCode(500, "Error occurred while processing your request");
            }
        }
    }
}