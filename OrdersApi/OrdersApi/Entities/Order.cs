// <copyright file="Order.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

namespace OrdersApi.Entities
{
    /// <summary>This is an order entity used to record information about orders placed in a system.</summary>
    /// <seealso cref="BaseEntity" />
    public class Order : BaseEntity
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public required string Name { get; set; }

        /// <summary>Gets or sets the date of order.</summary>
        /// <value>The date of order.</value>
        public DateTime DateOfOrder { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is open.</summary>
        /// <value><c>true</c> if this instance is open; otherwise, <c>false</c>.</value>
        public bool IsOpen { get; set; }

        /// <summary>Gets the order items.</summary>
        /// <value>The order items.</value>
        public ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
    }
}