// <copyright file="CategoryController.cs" company="Danieli Systec d.o.o.">
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
    /// <summary>Category controller class.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(DataContext context) : ControllerBase
    {
        private readonly DataContext context = context;

        /// <summary>Gets all categories.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await this.context.Category.Include(e => e.Restaurant).ToListAsync();
            return this.Ok(categories);
        }

        /// <summary>Gets the category.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await this.context.Category.FindAsync(id);
            if (category == null)
            {
                return this.NotFound();
            }

            return this.Ok(category);
        }

        /// <summary>Adds the category.</summary>
        /// <param name="category">The category.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category category)
        {
            category.CreatedDate = DateTime.Now;
            category.ModifiedDate = null;
            category.IsActive = true;
            var restaurant = await this.context.Restaurants.FindAsync(category.Id);
            if (restaurant == null)
            {
                
            }

            this.context.Category.Add(category);
            await this.context.SaveChangesAsync();
            return this.Ok(await this.context.Category.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Restaurant>>> UpdateCategory(Category updatedCategory)
        {
            var category = await this.context.Restaurants.FindAsync(updatedCategory.Id);
            if (category == null)
            {
                return this.NotFound();
            }

            category.Name = updatedCategory.Name;
            //category.TelephoneNumber = updatedCategory.TelephoneNumber;
            //category.Address = updatedCategory.Address;
            category.ModifiedDate = DateTime.Now;
            this.context.Restaurants.Update(category);
            await this.context.SaveChangesAsync();
            return this.Ok(await this.context.Restaurants.ToListAsync());
        }
    }
}
