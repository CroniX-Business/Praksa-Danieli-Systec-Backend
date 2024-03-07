using AutoMapper;
using OrdersApi.Entities;
using OrdersApi.Dto;
using FluentAssertions;
using OrdersApi;

namespace OrdersUnitTests.AutoMapperTest
{
    public class CustomerMapperTest
    {
        private readonly IMapper mapper;
        public CustomerMapperTest()
        {
            mapper = InitializeMapper.Initialize();
        }

        [Fact]
        public void CustomerToCustomerDtoMappingTest()
        {

            var customer = new Customer
            {
                Id = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123456",
            };

            var customerDto = mapper.Map<CustomerDto>(customer);

            customerDto.Should().NotBeNull();
            customerDto.Id.Should().Be(customer.Id);
            customerDto.FirstName.Should().BeEquivalentTo(customer.FirstName);
            customerDto.LastName.Should().BeEquivalentTo(customer.LastName);
            customerDto.PhoneNumber.Should().BeEquivalentTo(customer.PhoneNumber);
        }

        [Fact]
        public void CustomerDtoToCustomerMappingTest()
        {

            var customerDto = new CustomerDto
            {
                Id = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123456",
            };

            var customer = mapper.Map<Customer>(customerDto);

            customer.Should().NotBeNull();
            customer.Id.Should().Be(customerDto.Id);
            customer.FirstName.Should().BeEquivalentTo(customerDto.FirstName);
            customer.LastName.Should().BeEquivalentTo(customerDto.LastName);
            customer.PhoneNumber.Should().BeEquivalentTo(customerDto.PhoneNumber);
        }

    }
}
