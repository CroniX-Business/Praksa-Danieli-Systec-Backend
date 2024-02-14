// <copyright file="RestaurantController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    /// <summary>
    ///   Controller for restaurant to return data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        /// <summary>Gets the restaurant data.</summary>
        /// <returns>
        ///   Returns data of all restaurants.
        /// </returns>
        [HttpGet]
        public ActionResult<List<Restaurant>> GetAllRestaurants()
        {
            var restaurant = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "Test",
                    Address = "kralja mazuranica 21",
                    TelephoneNumber = "1234567890",
                },
            };
            return this.Ok(restaurant);
        }
    }
}
