using AutoMapper;
using FluentAssertions;
using OrdersApi.Dto;
using OrdersApi.Entities;

namespace OrdersUnitTests.AutoMapperTests
{
    public class CustomerMapperTests
    {
        private readonly IMapper mapper;
        public CustomerMapperTests()
        {
            mapper = InitializeMapper.Initialize();
        }

        [Fact]
        public void CustomerToCustomerDtoMappingTest()
        {
            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "1234567890",
            };

            var customerDto = mapper.Map<CustomerDto>(customer);

            customerDto.Should().NotBeNull();
            customerDto.Id.Should().Be(customer.Id);
            customerDto.FirstName.Should().BeEquivalentTo(customer.FirstName);
            customerDto.LastName.Should().BeEquivalentTo(customer.LastName);
            customerDto.PhoneNumber.Should().Be(customer.PhoneNumber);
        }

        [Fact]
        public void CustomerDtoToCustomerMappingTest()
        {

            var customerDto = new CustomerDto()
            {
                Id = 1,
                FirstName= "Test",
                LastName = "Test",
                PhoneNumber = "1234567890",
            };

            var customer = mapper.Map<Customer>(customerDto);

            customer.Should().NotBeNull();
            customer.Id.Should().Be(customerDto.Id);
            customer.FirstName.Should().BeEquivalentTo(customerDto.FirstName);
            customer.LastName.Should().BeEquivalentTo(customerDto.LastName);
            customer.PhoneNumber.Should().Be(customerDto.PhoneNumber);
        }
    }
}