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
            //Arrange
            var restaurantController = new RestaurantController(context, mapper, logger);

            //Act
            var result = restaurantController.GetAllRestaurants();

            //Assert
            result.Should().BeOfType<Task<ActionResult<IEnumerable<RestaurantDto>>>>();
        }

        [Fact]
        public void RestaurantController_GetRestaurant_ReturnsOk()
        {
            //Arrange
            var restaurantController = new RestaurantController(context, mapper, logger);
            var restaurant = new Restaurant()
            {
                Id = 1,
                Address = "Test",
                Name = "Test",
                PhoneNumber = "32131321",
            };

            //Act
            var result = restaurantController.GetRestaurant(restaurant.Id);

            //Assert
            result.Should().BeOfType<Task<ActionResult<RestaurantDto>>>();
        }

        [Fact]
        public void RestaurantController_AddRestaurant_ReturnsCreatedAtAction()
        {
            //Arrange
            var restaurantController = new RestaurantController(context, mapper, logger);
            var restaurantDto = new RestaurantDto()
            {
                Id = 1,
                Address = "Test",
                Name = "Test",
                PhoneNumber = "12321312312",
            };

            //Act
            var result = restaurantController.AddRestaurant(restaurantDto);

            //Assert
            result.Should().BeOfType<Task<ActionResult<RestaurantDto>>>();
        }

        [Fact]
        public void RestaurantController_UpdateRestaurant_ReturnsNoContent()
        {
            //Arrange
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

            //Act
            var result = restaurantController.UpdateRestaurant(restaurant.Id, restaurantDto);

            //Assert
            result.Should().BeOfType<Task<ActionResult<RestaurantDto>>>();
        }

        [Fact]
        public void RestaurantController_DeleteRestaurant_ReturnsNoContent()
        {
            //Arrange
            var restaurantController = new RestaurantController(context, mapper, logger);
            var restaurant = new Restaurant()
            {
                Id = 1,
                Address = "Test",
                Name = "Test",
                PhoneNumber = "32131321",
            };

            //Act
            var result = restaurantController.DeleteRestaurant(restaurant.Id);

            //Assert
            result.Should().BeOfType<Task<ActionResult>>();
        }
    }
}

