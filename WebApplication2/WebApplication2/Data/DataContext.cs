﻿// <copyright file="DataContext.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2.Data
{
    /// <summary>
    ///  Gives context for data base.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="DataContext" /> class.</remarks>
    /// <param name="options">The options.</param>
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        /// <summary>Gets or sets the restaurants.</summary>
        /// <value>The restaurants.</value>
        public DbSet<Restaurant> Restaurants { get; set; } = null!;

        /// <summary>Gets or sets the categories.</summary>
        /// <value>The categories.</value>
        public DbSet<Category> Categories { get; set; } = null!;

        /// <summary>Gets or sets the items.</summary>
        /// <value>The items.</value>
        public DbSet<Item> Items { get; set; } = null!;

        /// <summary>Gets or sets the order items.</summary>
        /// <value>The order items.</value>
        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        /// <summary>Gets or sets the users.</summary>
        /// <value>The users.</value>
        public DbSet<Customer> Users { get; set; } = null!;

        /// <summary>Gets or sets the orders.</summary>
        /// <value>The orders.</value>
        public DbSet<Order> Orders { get; set; } = null!;

        /// <summary>Gets or sets the prices.</summary>
        /// <value>The prices.</value>
        public DbSet<Price> Prices { get; set; } = null!;
    }
}
