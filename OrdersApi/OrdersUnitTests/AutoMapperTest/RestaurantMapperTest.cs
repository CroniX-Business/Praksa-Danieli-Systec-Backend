using AutoMapper;
using FluentAssertions;
using OrdersApi;
using OrdersApi.Dto;
using OrdersApi.Entities;

namespace OrdersUnitTests.AutoMapperTest
{
    public static class RestaurantMapperTest
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            return mapperConfig.CreateMapper();
        }
    }

    public class RestaurantMapperTests
    {
        private readonly IMapper _mapper;

        public RestaurantMapperTests()
        {
            _mapper = RestaurantMapperTest.Initialize();
        }

        [Fact]
        public void Map_RestaurantDto_To_Restaurant()
        {
            var restaurantDto = new RestaurantDto
            {
                Name = "Test Restaurant",
                Address = "123 Test St",
                PhoneNumber = "1234567890"
            };

            var restaurant = _mapper.Map<Restaurant>(restaurantDto);

            restaurant.Should().NotBeNull();
            restaurant.Name.Should().BeEquivalentTo(restaurantDto.Name);
            restaurant.Address.Should().BeEquivalentTo(restaurantDto.Address);
            restaurant.PhoneNumber.Should().BeEquivalentTo(restaurantDto.PhoneNumber);
        }

        [Fact]
        public void Map_Restaurant_To_RestaurantDto()
        {
            var restaurant = new Restaurant
            {
                Id = 1,
                Name = "Test Restaurant",
                Address = "123 Test St",
                PhoneNumber = "1234567890"
            };

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

            restaurantDto.Should().NotBeNull();
            restaurantDto.Id.Should().Be(restaurant.Id);
            restaurantDto.Name.Should().BeEquivalentTo(restaurant.Name);
            restaurantDto.Address.Should().BeEquivalentTo(restaurant.Address);
            restaurantDto.PhoneNumber.Should().BeEquivalentTo(restaurant.PhoneNumber);
        }
    }
}