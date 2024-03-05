// <copyright file="Customer.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

namespace OrdersApi.Entities
{
    /// <summary>This is a user entity used to store information about customers in a system.</summary>
    /// <seealso cref="BaseEntity" />
    public class Customer : BaseEntity
    {
        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public required string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.<value>
        public required string LastName { get; set; }

        /// <summary>Gets or sets the phone number.</summary>
        /// <value>The phone number.</value>
        public required string PhoneNumber { get; set; }

        /// <summary>Gets the order item.</summary>
        /// <value>The order item.</value>
        public ICollection<OrderItem> OrderItem { get; } = new List<OrderItem>();
    }
}