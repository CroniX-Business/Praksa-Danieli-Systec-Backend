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
    public class CustomerControllerTests
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly ILogger<CustomerController> logger;

        [Fact]
        public void CustomerController_GetAllCustomers_ReturnsOk()
        {
            var customerController = new CustomerController(context, mapper, logger);

            var result = customerController.GetAllCustomers();

            result.Should().BeOfType<Task<ActionResult<IEnumerable<CustomerDto>>>>();
        }

        [Fact]
        public void CustomerController_GetCustomer_ReturnsOk()
        {
            var customerController = new CustomerController(context, mapper, logger);
            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "21321312132",
            };

            //Act
            var result = customerController.GetCustomer(customer.Id);

            //Assert
            result.Should().BeOfType<Task<ActionResult<CustomerDto>>>();
        }

        [Fact]
        public void CustomerController_AddCustomer_ReturnsCreatedAtAction()
        {
            //Arrange
            var customerController = new CustomerController(context, mapper, logger);
            var customerDto = new CustomerDto()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "122132112",
            };

            //Act
            var result = customerController.AddCustomer(customerDto);

            //Assert
            result.Should().BeOfType<Task<ActionResult<CustomerDto>>>();
        }

        [Fact]
        public void CustomerController_UpdateCustomer_ReturnsNoContent()
        {
            //Arrange
            var customerController = new CustomerController(context, mapper, logger);
            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "21321312132",
            };
            var customerDto = new CustomerDto()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "122132112",
            };

            //Act
            var result = customerController.UpdateCustomer(customer.Id, customerDto);

            //Assert
            result.Should().BeOfType<Task<ActionResult<CustomerDto>>>();
        }

        [Fact]
        public void CustomerController_DeleteCustomer_ReturnsNoContent()
        {
            //Arrange
            var customerController = new CustomerController(context, mapper, logger);
            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "21321312132",
            };

            //Act
            var result = customerController.DeleteCustomer(customer.Id);

            //Assert
            result.Should().BeOfType<Task<ActionResult>>();
        }
    }
}
