// <copyright file="Category.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

namespace OrdersApi.Entities
{
    /// <summary>This is a category entity used for categorizing items in a system.</summary>
    /// <seealso cref="BaseEntity" />
    public class Category : BaseEntity
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public required string Name { get; set; }

        /// <summary>Gets or sets the sort.</summary>
        /// <value>The sort.</value>
        public int Sort { get; set; }

        /// <summary>Gets the items.</summary>
        /// <value>The items.</value>
        public ICollection<Item> Items { get; } = new List<Item>();
    }
}