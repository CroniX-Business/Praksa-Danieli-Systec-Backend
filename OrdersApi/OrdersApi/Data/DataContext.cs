// <copyright file="DataContext.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.EntityFrameworkCore;
using OrdersApi.Entities;
using OrdersApi.Interceptors;

namespace OrdersApi.Data
{
    /// <summary>Gives context for data base.</summary>
    /// <remarks>Initializes a new instance of the <see cref="DataContext" /> class.</remarks>
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        /// <summary>Gets or sets the restaurants.</summary>
        /// <value>The restaurants.</value>
        public DbSet<Restaurant> Restaurants { get; set; }

        /// <summary>Gets or sets the categories.</summary>
        /// <value>The categories.</value>
        public DbSet<Category> Categories { get; set; }

        /// <summary>Gets or sets the items.</summary>
        /// <value>The items.</value>
        public DbSet<Item> Items { get; set; }

        /// <summary>Gets or sets the order items.</summary>
        /// <value>The order items.</value>
        public DbSet<OrderItem> OrderItems { get; set; }

        /// <summary>Gets or sets the users.</summary>
        /// <value>The users.</value>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>Gets or sets the orders.</summary>
        /// <value>The orders.</value>
        public DbSet<Order> Orders { get; set; }

        /// <summary>Gets or sets the prices.</summary>
        /// <value>The prices.</value>
        public DbSet<Price> Prices { get; set; }

        /// <summary>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// The base implementation does nothing.
        /// </summary>
        /// <param name="optionsBuilder">
        /// A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.
        /// </param>
        /// <remarks>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions">DbContextOptions</see> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured">IsConfigured</see> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)">OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)</see>.
        /// See <a href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</a>
        /// for more information and examples.
        /// </remarks>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new EntitySaveChangesInterceptor());
        }
    }
}
