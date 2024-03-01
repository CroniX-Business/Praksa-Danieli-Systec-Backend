// <copyright file="RestaurantController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersApi.Data;
using OrdersApi.Dto;
using OrdersApi.Entities;

namespace OrdersApi.Controllers
{
    /// <summary>Controller for restaurant to return data.</summary>
    /// <remarks>Initializes a new instance of the <see cref="RestaurantController" /> class.</remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController(DataContext context, IMapper mapper, ILogger<RestaurantController> logger) : ControllerBase
    {
        private readonly DataContext context = context;

        private readonly IMapper mapper = mapper;

        private readonly ILogger<RestaurantController> logger = logger;

        /// <summary>Gets the restaurant data.</summary>
        /// <returns>Returns data of all restaurants.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAllRestaurants()
        {
            try
            {
                var restaurants = await this.context.Restaurants.Where(r => r.IsActive).ToListAsync();

                this.logger.LogDebug("Retrieved {Count} restaurants successfully.", restaurants.Count);

                return this.Ok(this.mapper.Map<List<RestaurantDto>>(restaurants));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while retrieving restaurants.");
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Gets the restaurant.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns restaurant by id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto>> GetRestaurant(int id)
        {
            try
            {
                var restaurant = await this.context.Restaurants.FirstOrDefaultAsync(r => r.Id == id && r.IsActive);

                if (restaurant is null)
                {
                    this.logger.LogWarning("Restaurant with ID {Id} not found.", id);

                    return this.NotFound();
                }

                this.logger.LogDebug("Retrieved restaurant with ID {Id} successfully.", id);
                return this.Ok(this.mapper.Map<RestaurantDto>(restaurant));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while retrieving restaurant with ID {Id}.", id);
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Adds the restaurant.</summary>
        /// <param name="newRestaurant">The new restaurant.</param>
        /// <returns>Returns restaurant.</returns>
        [HttpPost]
        public async Task<ActionResult<RestaurantDto>> AddRestaurant(RestaurantDto newRestaurant)
        {
            try
            {
                var restaurant = this.mapper.Map<Restaurant>(newRestaurant);
                this.context.Restaurants.Add(restaurant);
                await this.context.SaveChangesAsync();

                this.logger.LogDebug("Restaurant added successfully: {@Restaurant}.", restaurant);

                return this.CreatedAtAction(
                    nameof(this.AddRestaurant),
                    this.mapper.Map<RestaurantDto>(restaurant));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while adding a new restaurant: {@NewRestaurant}.", newRestaurant);
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Updates the restaurant.</summary>
        /// <param name="id">The identifier of restaurant we change.</param>
        /// <param name="updatedRestaurant">The updated restaurant.</param>
        /// <returns>Updates parameters of restaurant.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<RestaurantDto>> UpdateRestaurant(int id, RestaurantDto updatedRestaurant)
        {
            try
            {
                var dbRestaurant = await this.context.Restaurants.FirstOrDefaultAsync(r => r.Id == id && r.IsActive);
                if (dbRestaurant is null)
                {
                    this.logger.LogWarning("Restaurant with ID {Id} not found while updating.", id);
                    return this.NotFound();
                }

                dbRestaurant = this.mapper.Map(updatedRestaurant, dbRestaurant);

                await this.context.SaveChangesAsync();

                this.logger.LogDebug("Restaurant {@dbRestaurant} updated successfully.", dbRestaurant);
                return this.NoContent();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while updating restaurant with ID {Id}.", id);
                return this.StatusCode(500, "Error occurred while processing your request.");
            }
        }

        /// <summary>Deletes the restaurant.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Deletes restaurant by id.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRestaurant(int id)
        {
            try
            {
                var dbRestaurant = await this.context.Restaurants.FirstOrDefaultAsync(r => r.Id == id && r.IsActive);

                if (dbRestaurant is null)
                {
                    this.logger.LogWarning("Restaurant with ID {Id} not found while deleting.", id);
                    return this.NotFound();
                }

                dbRestaurant.IsActive = false;
                await this.context.SaveChangesAsync();

                this.logger.LogDebug("Restaurant with ID {Id} deleted successfully.", id);
                return this.NoContent();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while deleting restaurant with ID {Id}.", id);
                return this.StatusCode(500, "Error occurred while processing your request");
            }
        }
    }
}