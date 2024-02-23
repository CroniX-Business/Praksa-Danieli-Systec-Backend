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
    ///   Represents a Customer controller.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="CustomerController" /> class.</remarks>
    /// <param name="context">The context.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(IMapper mapper, DataContext context) : ControllerBase
    {
        private readonly DataContext context = context;
        private readonly IMapper mapper = mapper;

        /// <summary>Gets all Customers.</summary>
        /// <returns>
        ///   Returns list of Customers.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customers = await this.context.Customers.ToListAsync();

            return this.Ok(customers.Select(this.mapper.Map<CategoryDTO>));
        }

        /// <summary>Gets the Customer.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns Customer.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await this.context.Customers.FindAsync(id);
            if (customer == null)
            {
                return this.NotFound("Customer not found.");
            }

            /// <summary>Adds the customer.</summary>
            /// <param name="customer">The customer.</param>
            /// <returns>
            ///   Returns added customer.
            /// </returns>
            return this.Ok(this.mapper.Map<CustomerDTO>(customer));
        }

        /// <summary>Adds the customer.</summary>
        /// <param name="newCustomer">The new customer.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> AddCustomer(CustomerDTO newCustomer)
        {
            var customer = this.mapper.Map<Customer>(newCustomer);
            this.context.Customers.Add(customer);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(this.AddCustomer), await this.context.Customers.ToListAsync());
        }

        /// <summary>Updates the customer.</summary>
        /// <param name="updatedCustomer">The updated customer.</param>
        /// <returns>
        ///   Returns list of customers.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(CustomerDTO updatedCustomer, int id)
        {
            var dbCustomer = await this.context.Customers.FindAsync(id);
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
            var dbCustomer = await this.context.Customers.FindAsync(id);
            if (dbCustomer == null)
            {
                return this.NotFound("Customer not found.");
            }

            dbCustomer.ModifiedDate = DateTime.UtcNow;

            dbCustomer.IsActive = false;

            await this.context.SaveChangesAsync();

            return this.NoContent();
        }
    }
}
