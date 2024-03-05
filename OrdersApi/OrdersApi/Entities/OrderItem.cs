// <copyright file="OrderItem.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.EntityFrameworkCore;

namespace OrdersApi.Entities
{
    /// <summary>This represents an item within an order used to record details of items included in orders.</summary>
    /// <seealso cref="BaseEntity" />
    public class OrderItem : BaseEntity
    {
        /// <summary>Gets or sets the item identifier.</summary>
        /// <value>The item identifier.</value>
        public int ItemId { get; set; }

        /// <summary>Gets or sets the order identifier.</summary>
        /// <value>The order identifier.</value>
        public int OrderId { get; set; }

        /// <summary>Gets or sets the user identifier.</summary>
        /// <value>The user identifier.</value>
        public int CustomerId { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public required string Name { get; set; }

        /// <summary>Gets or sets the price.</summary>
        /// <value>The price.</value>
        [Precision(6, 2)]
        public decimal Amount { get; set; }

        /// <summary>Gets or sets the quantity.</summary>
        /// <value>The quantity.</value>
        public int Quantity { get; set; }

        /// <summary>Gets or sets the customer.</summary>
        /// <value>The customer.</value>
        public Customer? Customer { get; set; }

        /// <summary>Gets or sets the item.</summary>
        /// <value>The item.</value>
        public Item? Item { get; set; }
    }
}