// <copyright file="CustomerController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

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
    public class CustomerController(DataContext context) : ControllerBase
    {
        private readonly DataContext context = context;

        /// <summary>Gets all users.</summary>
        /// <returns>
        ///   Returns list of users.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            var customers = await this.context.Customers.Include(c => c.OrderItem).Where(c => c.IsActive).ToListAsync();

            return this.Ok(customers);
        }

        /// <summary>Gets the customer.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns customer.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Customer>>> GetCustomer(int id)
        {
            var customer = await this.context.Customers.Include(c => c.OrderItem).FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null || !customer.IsActive)
            {
                return this.NotFound("Customer not found.");
            }

            return this.Ok(customer);
        }

        /// <summary>Adds the customer.</summary>
        /// <param name="customer">The customer.</param>
        /// <returns>
        ///   Returns added customer.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(CustomerDTO newCustomer)
        {
            var customer = new Customer()
            {
                FirstName = newCustomer.FirstName,
                LastName = newCustomer.LastName,
                PhoneNumber = newCustomer.PhoneNumber,
            };

            customer.CreatedDate = DateTime.UtcNow;
            customer.ModifiedDate = null;
            this.context.Customers.Add(customer);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(this.AddCustomer), customer);
        }

        /// <summary>Updates the customer.</summary>
        /// <param name="updatedCustomer">The updated customer.</param>
        /// <returns>
        ///   Returns list of users.
        /// </returns>
        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(CustomerDTO updatedCustomer)
        {
            var dbCustomer = await this.context.Customers.FindAsync(updatedCustomer.Id);
            if (dbCustomer == null)
            {
                return this.NotFound("Customer not found.");
            }

            dbCustomer.FirstName = updatedCustomer.FirstName;
            dbCustomer.LastName = updatedCustomer.LastName;
            dbCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
            dbCustomer.ModifiedDate = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Customers.ToListAsync());
        }

        /// <summary>Deletes the customer.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns list of customer.
        /// </returns>
        [HttpDelete]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var dbUser = await this.context.Customers.FindAsync(id);
            if (dbUser == null)
            {
                return this.NotFound("Customer not found.");
            }

            dbUser.IsActive = false;
            dbUser.ModifiedDate = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Customers.ToListAsync());
        }
    }
}
