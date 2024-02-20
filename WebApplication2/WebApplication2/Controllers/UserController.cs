// <copyright file="UserController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>
/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    /// <summary>
    ///   Represents a user controller.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="UserController" /> class.</remarks>
    /// <param name="context">The context.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(DataContext context) : ControllerBase
    {
        private readonly DataContext context = context;

        /// <summary>Gets all users.</summary>
        /// <returns>
        ///   Returns list of users.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllUsers()
        {
            var users = await this.context.Users.ToListAsync();

            return this.Ok(users);
        }

        /// <summary>Gets the user.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns user.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Customer>>> GetUser(int id)
        {
            var user = await this.context.Users.FindAsync(id);
            if (user == null)
            {
                return this.NotFound("User not found.");
            }

            return this.Ok(user);
        }

        /// <summary>Adds the user.</summary>
        /// <param name="user">The user.</param>
        /// <returns>
        ///   Returns added user.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddUser(Customer user)
        {
            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Users.ToListAsync());
        }

        /// <summary>Updates the user.</summary>
        /// <param name="updatedUser">The updated user.</param>
        /// <returns>
        ///   Returns list of users.
        /// </returns>
        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateUser(Customer updatedUser)
        {
            var dbUser = await this.context.Users.FindAsync(updatedUser.Id);
            if (dbUser == null)
            {
                return this.NotFound("User not found.");
            }

            dbUser.Id = updatedUser.Id;
            dbUser.LastName = updatedUser.LastName;
            dbUser.Telephone = updatedUser.PhoneNumber;
            dbUser.Name = updatedUser.FirstName;

            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Users.ToListAsync());
        }

        /// <summary>Deletes the user.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Returns list of users.
        /// </returns>
        [HttpDelete]
        public async Task<ActionResult<List<Customer>>> DeleteUser(int id)
        {
            var dbUser = await this.context.Users.FindAsync(id);
            if (dbUser == null)
            {
                return this.NotFound("User not found.");
            }

            this.context.Users.Remove(dbUser);

            await this.context.SaveChangesAsync();

            return this.Ok(await this.context.Users.ToListAsync());
        }
    }
}

*/