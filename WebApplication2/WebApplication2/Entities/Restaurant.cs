// <copyright file="Restaurant.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.Extensions.Hosting;

namespace WebApplication2.Entities
{
    /// <summary>
    /// This is a restaurant entity used to store information about restaurants in a system.
    /// </summary>
    public class Restaurant
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public required string Address { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        public required string TelephoneNumber { get; set; }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public ICollection<Category> Categories { get; } = new List<Category>();
    }
}
