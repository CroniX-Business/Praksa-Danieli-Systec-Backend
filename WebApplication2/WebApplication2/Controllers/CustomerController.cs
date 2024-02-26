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
    public class CustomerController(IMapper mapper, DataContext context) : ControllerBase
    {
        private readonly DataContext context = context;

        private readonly IMapper mapper = mapper;

        /// <summary>Gets all customers.</summary>
        /// <returns>
        ///   Returns list of customers.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
        {
            var customers = await this.context.Customers.Where(c => c.IsActive).ToListAsync();

            return this.Ok(customers.Select(this.mapper.Map<CustomerDTO>));
        }

        /// <summary>Gets the customer.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns customer.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            var customer = await this.context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null || !customer.IsActive)
            {
                return this.NotFound("Customer not found.");
            }

            return this.Ok(this.mapper.Map<CustomerDTO>(customer));
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
        /// <param name="id">id of customer.</param>
        /// <returns>Returns list of customers.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDTO>> UpdateCustomer(CustomerDTO updatedCustomer, int id)
        {
            var dbCustomer = await this.context.Customers.FirstOrDefaultAsync(r => r.Id == id);
            if (dbCustomer == null)
            {
                return this.NotFound("Customer not found.");
            }

            updatedCustomer.CreatedDate = dbCustomer.CreatedDate;

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
