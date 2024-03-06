using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrdersApi.Controllers;
using OrdersApi.Data;
using OrdersApi.Dto;

namespace OrdersUnitTests.ControllerTest
{
    public class CustomerControllerTests
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly ILogger<CustomerController> logger;

        [Fact]
        public void GetAllTest()
        {
            var controller = new CustomerController(context, mapper, logger);

            var result = controller.GetAllCustomers();

            result.Should().BeOfType<Task<ActionResult<IEnumerable<CustomerDto>>>>();
        }
        [Fact]
        public void GetCustomerTest()
        {
            var controller = new CustomerController(context, mapper, logger);

            var result = controller.GetCustomer(1);

            result.Should().BeOfType<Task<ActionResult<CustomerDto>>>();
        }

        [Fact]
        public void AddCustomerTest()
        {
            var controller = new CustomerController(context, mapper, logger);

            var customer = new CustomerDto
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123456",
            };

            var result = controller.AddCustomer(customer);

            result.Should().BeOfType<Task<ActionResult<CustomerDto>>>();

        }
        [Fact]
        public void UpdateCustomerTest()
        {
            var controller = new CustomerController(context, mapper, logger);

            var customer = new CustomerDto
            {
                Id = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123456",
            };

            var newCustomer = new CustomerDto
            {
                Id = 1,
                FirstName = "NewTestFirstName",
                LastName = "NewTestLastName",
                PhoneNumber = "123456",
            };

            controller.AddCustomer(customer);

            var result = controller.UpdateCustomer(customer.Id, newCustomer);

            result.Should().BeOfType<Task<ActionResult<CustomerDto>>>();
        }

        [Fact]
        public void DeleteCustomerTest()
        {
            var controller = new CustomerController(context, mapper, logger);

            var result = controller.DeleteCustomer(1);

            result.Should().BeOfType<Task<ActionResult>>();
        }
    }
}
