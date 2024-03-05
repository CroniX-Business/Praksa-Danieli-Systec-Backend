// <copyright file="Item.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

namespace OrdersApi.Entities
{
    /// <summary>This is an item entity used to describe individual items within a system.</summary>
    /// <seealso cref="BaseEntity" />
    public class Item : BaseEntity
    {
        /// <summary>Gets or sets the category identifier.</summary>
        /// <value>The category identifier.</value>
        public int CategoryId { get; set; }

        /// <summary>Gets or sets the restaurant identifier.</summary>
        /// <value>The restaurant identifier.</value>
        public int RestaurantId { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public required string Name { get; set; }

        /// <summary>Gets or sets the sort.</summary>
        /// <value>The sort.</value>
        public int Sort { get; set; }

        /// <summary>Gets or sets the order item.</summary>
        /// <value>The order item.</value>
        public OrderItem? OrderItem { get; set; }

        /// <summary>Gets the prices.</summary>
        /// <value>The prices.</value>
        public ICollection<Price> Prices { get; } = new List<Price>();
    }
}