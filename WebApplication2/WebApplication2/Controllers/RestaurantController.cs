// <copyright file="RestaurantController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
            try
            {
                var restaurants = await this.context.Restaurants.Where(r => r.IsActive).ToListAsync();

                Log.Information("Retrieved restaurants successfully");

                return this.Ok(restaurants.Select(this.mapper.Map<RestaurantDTO>));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while retrieving restaurants");
                return this.StatusCode(500, "Error occured while processing request.");
            }
        }

        /// <summary>Gets the restaurant.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///  Returns restaurant by id.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurant(int id)
        {
            try
            {
                var restaurant = await this.context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
                if (restaurant is null || !restaurant.IsActive)
                {
                    Log.Warning("Restaurant not found or not active.");
                    return this.NotFound("Restaurant not found");
                }

                Log.Information("Restaurant found and returned successfully.");
                return this.Ok(this.mapper.Map<RestaurantDTO>(restaurant));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing the request.");
                return this.StatusCode(500, "Error occurred while processing request");
            }
        }

        /// <summary>Adds the restaurant.</summary>
        /// <param name="newRestaurant">The new restaurant.</param>
        /// <returns>
        ///   Returns restaurant.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<RestaurantDTO>> AddRestaurant(RestaurantDTO newRestaurant)
        {
            try
            {
                var restaurant = this.mapper.Map<Restaurant>(newRestaurant);
                this.context.Restaurants.Add(restaurant);
                await this.context.SaveChangesAsync();

                Log.Information("Restaurant added successfully: {Restaurant}", restaurant);

                return this.CreatedAtAction(nameof(this.AddRestaurant), this.mapper.Map<RestaurantDTO>(restaurant));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while adding a new restaurant: {NewRestaurant}", newRestaurant);
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Updates the restaurant.</summary>
        /// <param name="updatedRestaurant">The updated restaurant.</param>
        /// <param name="id">The indentifier of restaurant we change.</param>
        /// <returns>Updates parameters of restaurant.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<RestaurantDTO>> UpdateRestaurant(RestaurantDTO updatedRestaurant, int id)
        {
            try
            {
                var dbRestaurant = await this.context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
                if (dbRestaurant is null)
                {
                    Log.Warning("Restaurant's not found while");
                    return this.NotFound("Restaurant not found");
                }

                dbRestaurant = this.mapper.Map(updatedRestaurant, dbRestaurant);

                await this.context.SaveChangesAsync();

                Log.Information("Restaurant updated successfully");
                return this.NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while updating restaurant.");
                return this.StatusCode(500, "Error occurred while processing your request");
            }
        }

        /// <summary>Deletes the restaurant.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///  Deletes restaurant by id.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRestaurant(int id)
        {
            try
            {
                var dbRestaurant = await this.context.Restaurants.FindAsync(id);
                if (dbRestaurant is null)
                {
                    Log.Warning("Restaurant not found while deleting");
                    return this.NotFound("Restaurant not found");
                }

                dbRestaurant.IsActive = false;
                dbRestaurant.ModifiedDate = DateTime.UtcNow;
                await this.context.SaveChangesAsync();

                Log.Information("Restaurant deleted successfully");
                return this.NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while deleting restaurant");
                return this.StatusCode(500, "Error occurred while processing your request");
            }
        }
    }
}