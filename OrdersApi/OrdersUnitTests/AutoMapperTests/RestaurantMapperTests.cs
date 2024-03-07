using AutoMapper;
using FluentAssertions;
using OrdersApi.Dto;
using OrdersApi.Entities;

namespace OrdersUnitTests.AutoMapperTests
{
    public class RestaurantMapperTests
    {
        private readonly IMapper mapper;
        public RestaurantMapperTests()
        {
            mapper = InitializeMapper.Initialize();
        }

        [Fact]
        public void RestaurantToRestaurantDtoMappingTest()
        {

            var restaurant = new Restaurant
            {
                Id = 1,
                Name = "TestRestaurant",
                Address = "TestAddress",
                PhoneNumber = "123456",
            };

            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

            restaurantDto.Should().NotBeNull();
            restaurantDto.Id.Should().Be(restaurant.Id);
            restaurantDto.Name.Should().BeEquivalentTo(restaurant.Name);
            restaurantDto.Address.Should().BeEquivalentTo(restaurant.Address);
            restaurantDto.PhoneNumber.Should().BeEquivalentTo(restaurant.PhoneNumber);
        }

        [Fact]
        public void RestaurantDtoToRestaurantMappingTest()
        {

            var restaurantDto = new RestaurantDto
            {
                //Id = 1,
                Name = "TestRestaurant",
                Address = "TestAddress",
                PhoneNumber = "123456",
            };

            var restaurant = mapper.Map<Restaurant>(restaurantDto);

            restaurant.Should().NotBeNull();
            restaurant.Id.Should().Be(restaurantDto.Id);
            restaurant.Name.Should().BeEquivalentTo(restaurantDto.Name);
            restaurant.Address.Should().BeEquivalentTo(restaurantDto.Address);
            restaurant.PhoneNumber.Should().BeEquivalentTo(restaurantDto.PhoneNumber);
        }

    }
}
