// <copyright file="CustomerController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    /// <summary>
    ///   Represents a customer controller.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="CustomerController" /> class.</remarks>
    /// <param name="context">The context.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(IMapper mapper, DataContext context, ILogger<CustomerController> logger) : ControllerBase
    {
        private readonly DataContext context = context;

        private readonly IMapper mapper = mapper;

        private readonly ILogger<CustomerController> logger = logger;

        /// <summary>Gets all customers.</summary>
        /// <returns>
        ///   Returns list of customers.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
        {
            try
            {
                var customers = await this.context.Customers.Where(r => r.IsActive).ToListAsync();

                this.logger.LogDebug("Retrieved {Count} customers successfully.", customers.Count);

                return this.Ok(customers.Select(this.mapper.Map<CustomerDTO>));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while retrieving customers.");
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Gets the customer.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns customer.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            try
            {
                var customer = await this.context.Customers.FirstOrDefaultAsync(r => r.Id == id);
                if (customer is null || !customer.IsActive)
                {
                    this.logger.LogWarning("Customer with ID {Id} not found.", id);

                    return this.NotFound();
                }

                this.logger.LogDebug("Retrieved customer with ID {Id} successfully.", id);
                return this.Ok(this.mapper.Map<CustomerDTO>(customer));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while retrieving customer with ID {Id}.", id);
                return this.StatusCode(500, "Error occurred while processing request.");
            }
        }

        /// <summary>Adds the customer.</summary>
        /// <param name="newCustomer">The new customer.</param>
        /// <returns>
        ///   Returns customer.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> AddCustomer(CustomerDTO newCustomer)
        {
            var customer = this.mapper.Map<Customer>(newCustomer);
            this.context.Customers.Add(customer);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(this.AddCustomer), this.mapper.Map<CustomerDTO>(customer));
        }

        /// <summary>Updates the customer.</summary>
        /// <param name="updatedCustomer">The updated customer.</param>
        /// <param name="id">The identifier of customer we change.</param>
        /// <returns>Returns list of customers.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDTO>> UpdateCustomer(CustomerDTO updatedCustomer, int id)
        {
            var dbCustomer = await this.context.Customers.FirstOrDefaultAsync(r => r.Id == id);
            if (dbCustomer == null)
            {
                return this.NotFound("Customer not found.");
            }

            this.mapper.Map(updatedCustomer, dbCustomer);

            await this.context.SaveChangesAsync();

            return this.NoContent();
        }

        /// <summary>Deletes the customer.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns list of customers.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var dbUser = await this.context.Customers.FindAsync(id);
            if (dbUser == null)
            {
                return this.NotFound("Customer not found.");
            }

            dbUser.IsActive = false;
            dbUser.ModifiedDate = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return this.NoContent();
        }
    }
}
