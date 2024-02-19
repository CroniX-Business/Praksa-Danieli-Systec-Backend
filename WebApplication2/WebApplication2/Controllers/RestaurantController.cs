// <copyright file="RestaurantController.cs" company="Danieli Systec d.o.o.">
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
    ///   Controller for restaurant to return data.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="RestaurantController" /> class.</remarks>
    /// <param name="context">The context.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController(DataContext context) : ControllerBase
    {
        /// <summary>The context.</summary>
        private readonly DataContext context = context;

        /// <summary>Gets the restaurant data.</summary>
        /// <returns>Returns data of all restaurants.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants()
        {
            var restaurant = await this.context.Restaurants.Include(r => r.Categories).ToListAsync();
            return this.Ok(restaurant);
        }

        /// <summary>Gets the restaurant.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///  Returns restaurant by id.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await this.context.Restaurants.Include(r => r.Categories).FirstOrDefaultAsync(r => r.Id == id);
            if (restaurant is null)
            {
                return this.NotFound("Restaurant not found");
            }

            return this.Ok(restaurant);
        }

        /// <summary>Adds the restaurant.</summary>
        /// <param name="restaurant">The restaurant.</param>
        /// <returns>
        ///  Posts restaurant to database.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<List<Restaurant>>> AddRestaurant(Restaurant restaurant)
        {
            restaurant.IsActive = true;
            restaurant.CreatedDate = DateTime.Now;
            restaurant.ModifiedDate = null;
            this.context.Restaurants.Add(restaurant);
            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Restaurants.ToListAsync());
        }

        /// <summary>Updates the restaurant.</summary>
        /// <param name="updatedRestaurant">The updated restaurant.</param>
        /// <returns>
        ///  Updates parameters of restaurant.
        /// </returns>
        [HttpPut]
        public async Task<ActionResult<List<Restaurant>>> UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var dbRestaurant = await this.context.Restaurants.FindAsync(updatedRestaurant.Id);
            if (dbRestaurant is null)
            {
                return this.NotFound("Restaurant not found");
            }

            updatedRestaurant.CreatedDate = dbRestaurant.CreatedDate;
            dbRestaurant.ModifiedDate = DateTime.Now;

            dbRestaurant.Name = updatedRestaurant.Name;
            dbRestaurant.Address = updatedRestaurant.Address;
            dbRestaurant.TelephoneNumber = updatedRestaurant.TelephoneNumber;

            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Restaurants.ToListAsync());
        }

        /// <summary>Deletes the restaurant.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///  Deletes restaurant by id.
        /// </returns>
        [HttpDelete]
        public async Task<ActionResult<List<Restaurant>>> DeleteRestaurant(int id)
        {
            var dbRestaurant = await this.context.Restaurants.FindAsync(id);
            if (dbRestaurant is null)
            {
                return this.NotFound("Restaurant not found");
            }

            dbRestaurant.IsActive = false;
            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Restaurants.ToListAsync());
        }
    }
}
