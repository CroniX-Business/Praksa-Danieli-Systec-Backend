using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrdersApi.Controllers;
using OrdersApi.Data;
using OrdersApi.Dto;

namespace OrdersUnitTests.ControllerTest
{
    public class RestaurantControllerTests
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly ILogger<RestaurantController> logger;

        [Fact]
        public void GetAllTest()
        {
            var controller = new RestaurantController(context, mapper, logger);

            var result = controller.GetAllRestaurants();

            result.Should().BeOfType<Task<ActionResult<IEnumerable<RestaurantDto>>>>();
        }
        [Fact]
        public void GetRestaurantTest()
        {
            var controller = new RestaurantController(context, mapper, logger);
            
            var result = controller.GetRestaurant(1);

            result.Should().BeOfType<Task<ActionResult<RestaurantDto>>>();
        }

        [Fact]
        public void AddRestaurantTest() 
        {
            var controller = new RestaurantController(context, mapper, logger);

            var restaurant = new RestaurantDto
            {
                Name = "TestRestaurant",
                Address = "TestAddress",
                PhoneNumber = "123456",
            };

            var result = controller.AddRestaurant(restaurant);

            result.Should().BeOfType<Task<ActionResult<RestaurantDto>>>();

        }
    }
}
