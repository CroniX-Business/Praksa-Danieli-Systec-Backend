// <copyright file="Order.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

namespace WebApplication2.Entities
{
    /// <summary>Entity of order.</summary>
    public class Order
    {
        /// <summary>Gets or sets the identifier for ID.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the date of order.</summary>
        /// <value>The date of order.</value>
        public DateTime DateOfOrder { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="Order" /> is status.</summary>
        /// <value>
        ///   <c>true</c> if status; otherwise, <c>false</c>.</value>
        public bool Status { get; set; }
    }
}
