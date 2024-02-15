// <copyright file="UserController.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    /// <summary>
    ///   Represents a user controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext context;

        /// <summary>Initializes a new instance of the <see cref="UserController" /> class.</summary>
        /// <param name="context">The context.</param>
        public UserController(DataContext context)
        {
            this.context = context;
        }

        /// <summary>Gets all users.</summary>
        /// <returns>
        ///   Returns list of users.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await this.context.Users.ToListAsync();

            return this.Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUser(int id)
        {
            var user = await this.context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return this.Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            this.context.Users.Add(user);
            await context.SaveChangesAsync();

            return this.Ok(await context.Users.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User updatedUser)
        {
            var dbUser = await this.context.Users.FindAsync(updatedUser.Id);
            if (dbUser == null)
            {
                return NotFound("User not found.");
            }

            dbUser.Id = updatedUser.Id;
            dbUser.LastName = updatedUser.LastName;
            dbUser.Telephone = updatedUser.Telephone;
            dbUser.Name = updatedUser.Name;

            await context.SaveChangesAsync();

            return this.Ok(await context.Users.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var dbUser = await this.context.Users.FindAsync(id);
            if (dbUser == null)
            {
                return NotFound("User not found.");
            }

            context.Users.Remove(dbUser);

            await context.SaveChangesAsync();

            return this.Ok(await context.Users.ToListAsync());
        }
    }
}
