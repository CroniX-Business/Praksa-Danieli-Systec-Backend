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
    ///   Represents a restaurant controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly DataContext context;

        /// <summary>Initializes a new instance of the <see cref="RestaurantController" /> class.</summary>
        /// <param name="context">The context.</param>
        public RestaurantController(DataContext context)
        {
            this.context = context;
        }

        /// <summary>Gets all restaurants.</summary>
        /// <returns>
        ///   Returns list of restaurants.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants()
        {
            var restaurants = await this.context.Restaurants.Include(r => r.Categories).ToListAsync();

            return this.Ok(restaurants);
        }

        /// <summary>Gets the restaurant.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns restaurant.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurant(int id)
        {
            var restaurant = await this.context.Restaurants.Include(r => r.Categories).FirstOrDefaultAsync(r => r.Id == id);
            if (restaurant == null)
            {
                return this.NotFound("Restaurant not found.");
            }

            return this.Ok(restaurant);
        }

        /// <summary>Adds the restaurant.</summary>
        /// <param name="restaurant">The restaurant.</param>
        /// <returns>
        ///   Returns list of restaurants.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<List<Restaurant>>> AddRestaurant(Restaurant restaurant)
        {
            restaurant.ModifiedDate = null;
            restaurant.CreatedDate = DateTime.Now;
            this.context.Restaurants.Add(restaurant);
            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Restaurants.ToListAsync());
        }

        /// <summary>Updates the restaurant.</summary>
        /// <param name="updatedRestaurant">The updated restaurant.</param>
        /// <returns>
        ///   Returns list of restaurants.
        /// </returns>
        [HttpPut]
        public async Task<ActionResult<List<Restaurant>>> UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var dbRestaurant = await this.context.Restaurants.FindAsync(updatedRestaurant.Id);
            if (dbRestaurant == null)
            {
                return this.NotFound("Restaurant not found.");
            }

            dbRestaurant.Id = updatedRestaurant.Id;
            dbRestaurant.Name = updatedRestaurant.Name;
            dbRestaurant.Address = updatedRestaurant.Address;
            dbRestaurant.TelephoneNumber = updatedRestaurant.TelephoneNumber;
            updatedRestaurant.CreatedDate = dbRestaurant.CreatedDate;
            dbRestaurant.ModifiedDate = DateTime.Now;

            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Restaurants.ToListAsync());
        }

        /// <summary>Deletes the restaurant.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns list of restaurants.
        /// </returns>
        [HttpDelete]
        public async Task<ActionResult<List<Restaurant>>> DeleteRestaurant(int id)
        {
            var dbRestaurant = await this.context.Restaurants.FindAsync(id);
            if (dbRestaurant == null)
            {
                return this.NotFound("Restaurant not found.");
            }

            dbRestaurant.IsActive = false;

            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Restaurants.ToListAsync());
        }
    }
}
