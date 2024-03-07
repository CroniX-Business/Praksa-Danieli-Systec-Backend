using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrdersApi.Controllers;
using OrdersApi.Data;
using OrdersApi.Dto;
using OrdersApi.Entities;

namespace OrdersUnitTests.ControllersTests
{
    public class RestaurantControllerTests
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly ILogger<RestaurantController> logger;

        [Fact]
        public void RestaurantController_GetAllRestaurants_ReturnsOk()
        {
            var restaurantController = new RestaurantController(context, mapper, logger);

            var result = restaurantController.GetAllRestaurants();

            result.Should().BeOfType<Task<ActionResult<IEnumerable<RestaurantDto>>>>();
        }

        [Fact]
        public void RestaurantController_GetRestaurant_ReturnsOk()
        {
            var restaurantController = new RestaurantController(context, mapper, logger);
            var restaurant = new Restaurant()
            {
                Id = 1,
                Address = "Test",
                Name = "Test",
                PhoneNumber = "32131321",
            };

            var result = restaurantController.GetRestaurant(restaurant.Id);

            result.Should().BeOfType<Task<ActionResult<RestaurantDto>>>();
        }

        [Fact]
        public void RestaurantController_AddRestaurant_ReturnsCreatedAtAction()
        {
            var restaurantController = new RestaurantController(context, mapper, logger);
            var restaurantDto = new RestaurantDto()
            {
                Id = 1,
                Address = "Test",
                Name = "Test",
                PhoneNumber = "12321312312",
            };

            var result = restaurantController.AddRestaurant(restaurantDto);

            result.Should().BeOfType<Task<ActionResult<RestaurantDto>>>();
        }

        [Fact]
        public void RestaurantController_UpdateRestaurant_ReturnsNoContent()
        {
            var restaurantController = new RestaurantController(context, mapper, logger);
            var restaurant = new Restaurant()
            {
                Id = 1,
                Address = "Test",
                Name = "Test",
                PhoneNumber = "32131321",
            };
            var restaurantDto = new RestaurantDto()
            {
                Id = 1,
                Address = "Test",
                Name = "Test",
                PhoneNumber = "12321312312",
            };

            var result = restaurantController.UpdateRestaurant(restaurant.Id, restaurantDto);

            result.Should().BeOfType<Task<ActionResult<RestaurantDto>>>();
        }

        [Fact]
        public void RestaurantController_DeleteRestaurant_ReturnsNoContent()
        {
            var restaurantController = new RestaurantController(context, mapper, logger);
            var restaurant = new Restaurant()
            {
                Id = 1,
                Address = "Test",
                Name = "Test",
                PhoneNumber = "32131321",
            };

            var result = restaurantController.DeleteRestaurant(restaurant.Id);

            result.Should().BeOfType<Task<ActionResult>>();
        }
    }
}

