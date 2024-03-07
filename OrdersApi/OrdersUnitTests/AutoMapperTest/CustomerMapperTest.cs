using AutoMapper;
using FluentAssertions;
using OrdersApi;
using OrdersApi.Dto;
using OrdersApi.Entities;

namespace OrdersUnitTests.AutoMapperTest
{
    public static class CustomerMapperTest
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

    public class CustomerMapperTests
    {
        private readonly IMapper _mapper;

        public CustomerMapperTests()
        {
            _mapper = CustomerMapperTest.Initialize();
        }

        [Fact]
        public void Map_CustomerDto_To_Customer()
        {
            var customerDto = new CustomerDto
            {
                FirstName = "Test",
                LastName = "Customer",
                PhoneNumber = "1234567890",
            };

            var customer = _mapper.Map<Customer>(customerDto);

            customer.Should().NotBeNull();
            customer.FirstName.Should().BeEquivalentTo(customerDto.FirstName);
            customer.LastName.Should().Be(customerDto.LastName);
            customer.PhoneNumber.Should().Be(customerDto.PhoneNumber);
        }

        [Fact]
        public void Map_Customer_To_CustomerDto()
        {
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "21321312132",
            };

            var customerDto = _mapper.Map<CustomerDto>(customer);

            customerDto.Should().NotBeNull();
            customerDto.Id.Should().Be(customer.Id);
            customer.FirstName.Should().BeEquivalentTo(customerDto.FirstName);
            customer.LastName.Should().Be(customerDto.LastName);
            customer.PhoneNumber.Should().Be(customerDto.PhoneNumber);
        }
    }
}