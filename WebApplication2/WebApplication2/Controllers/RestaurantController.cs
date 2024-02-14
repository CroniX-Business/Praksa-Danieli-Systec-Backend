// <copyright file="RestaurantController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.AspNetCore.Mvc;
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
        /// <summary>Gets all restaurants.</summary>
        /// <returns>
        ///   Returns list of restaurants.
        /// </returns>
        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Id = 1,
                    Name = "Test",
                    Address = "A.Hebranga 129",
                    TelephoneNumber = "1234567890",
                },
            };

            return this.Ok(restaurants);
        }
    }
}
