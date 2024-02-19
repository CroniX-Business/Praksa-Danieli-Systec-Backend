// <copyright file="RestaurantController.cs" company="Danieli Systec d.o.o.">
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
    /// <summary>Restaurant controller class.</summary>
    [Route("api/[controller]")]
    [ApiController]

    public class RestaurantController(DataContext context) : ControllerBase
    {
        private readonly DataContext context = context;

        /// <summary>Gets all restaurants.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants()
        {
            var restaurants = await this.context.Restaurants.Include(r => r.Categories).ToListAsync();
            return Ok(restaurants);
        }

        /// <summary>Gets the restaurant.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await this.context.Restaurants.Include(r => r.Categories).ToListAsync();
            if (restaurant == null)
            {
                return this.NotFound();
            }

            return this.Ok(restaurant);
        }

        /// <summary>Adds the restaurant.</summary>
        /// <param name="restaurant">The restaurant.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<List<Restaurant>>> AddRestaurant(Restaurant restaurant)
        {
            restaurant.CreatedDate = DateTime.Now;
            restaurant.ModifiedDate = null;
            restaurant.IsActive = true;
            this.context.Restaurants.Add(restaurant);
            await this.context.SaveChangesAsync();
            return this.Ok(await this.context.Restaurants.ToListAsync());
        }

        /// <summary>Updates the restaurant.</summary>
        /// <param name="updatedRestaurant">The updated restaurant.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPut]
        public async Task<ActionResult<List<Restaurant>>> UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var restaurant = await this.context.Restaurants.FindAsync(updatedRestaurant.Id);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            restaurant.Name = updatedRestaurant.Name;
            restaurant.TelephoneNumber = updatedRestaurant.TelephoneNumber;
            restaurant.Address = updatedRestaurant.Address;
            restaurant.ModifiedDate = DateTime.Now;
            this.context.Restaurants.Update(restaurant);
            await this.context.SaveChangesAsync();
            return this.Ok(await this.context.Restaurants.ToListAsync());
        }

        /// <summary>Deletes the restaurant.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpDelete]
        public async Task<ActionResult<List<Restaurant>>> DeleteRestaurant(int id)
        {
            var restaurant = await this.context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            restaurant.IsActive = false;
            await this.context.SaveChangesAsync();
            return this.Ok(await this.context.Restaurants.ToListAsync());
        }
    }
}
