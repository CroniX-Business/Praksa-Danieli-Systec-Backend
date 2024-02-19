﻿// <copyright file="Order.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

namespace WebApplication2.Entities
{
    /// <summary>
    /// This is an order entity used to record information about orders placed in a system.
    /// </summary>
    public class Order : BaseEntity
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the date of order.</summary>
        /// <value>The date of order.</value>
        public DateTime DateOfOrder { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="Order" /> is status.</summary>
        /// <value>
        /// <c>true</c> if status; otherwise, <c>false</c>.</value>
        public bool Status { get; set; }

        /// <summary>Gets the order items.</summary>
        /// <value>The order items.</value>
        public ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
    }
}