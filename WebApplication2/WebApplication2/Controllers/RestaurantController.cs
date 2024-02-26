// <copyright file="RestaurantController.cs" company="Danieli Systec d.o.o.">
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
    ///   Controller for restaurant to return data.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="RestaurantController" /> class.</remarks>
    /// <param name="context">The context.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController(IMapper mapper, DataContext context) : ControllerBase
    {
        /// <summary>The context.</summary>
        private readonly DataContext context = context;

        private readonly IMapper mapper = mapper;

        /// <summary>Gets the restaurant data.</summary>
        /// <returns>Returns data of all restaurants.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> GetAllRestaurants()
        {
            var restaurants = await this.context.Restaurants.Where(r => r.IsActive).ToListAsync();

            return this.Ok(restaurants.Select(this.mapper.Map<RestaurantDTO>));
        }

        /// <summary>Gets the restaurant.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///  Returns restaurant by id.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurant(int id)
        {
            var restaurant = await this.context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
            if (restaurant is null || !restaurant.IsActive)
            {
                return this.NotFound("Restaurant not found");
            }

            return this.Ok(this.mapper.Map<RestaurantDTO>(restaurant));
        }

        /// <summary>Adds the restaurant.</summary>
        /// <param name="newRestaurant">The new restaurant.</param>
        /// <returns>
        ///   Returns restaurant.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<RestaurantDTO>> AddRestaurant(RestaurantDTO newRestaurant)
        {
            var restaurant = this.mapper.Map<Restaurant>(newRestaurant);
            this.context.Restaurants.Add(restaurant);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(this.AddRestaurant), this.mapper.Map<RestaurantDTO>(restaurant));
        }

        /// <summary>Updates the restaurant.</summary>
        /// <param name="updatedRestaurant">The updated restaurant.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns no content.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRestaurant(RestaurantDTO updatedRestaurant, int id)
        {
            var dbRestaurant = await this.context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
            if (dbRestaurant is null)
            {
                return this.NotFound("Restaurant not found");
            }

            this.mapper.Map(updatedRestaurant, dbRestaurant);

            await this.context.SaveChangesAsync();

            return this.NoContent();
        }

        /// <summary>Deletes the restaurant.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///  Returns no content.
        /// </returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteRestaurant(int id)
        {
            var dbRestaurant = await this.context.Restaurants.FindAsync(id);
            if (dbRestaurant is null)
            {
                return this.NotFound("Restaurant not found");
            }

            dbRestaurant.IsActive = false;
            dbRestaurant.ModifiedDate = DateTime.UtcNow;
            await this.context.SaveChangesAsync();

            return this.NoContent();
        }
    }
}
