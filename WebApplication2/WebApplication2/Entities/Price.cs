﻿// <copyright file="Price.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

namespace WebApplication2.Entities
{
    /// <summary>
    ///   <br />
    /// </summary>
    public class Price : BaseEntity
    {
        /// <summary>Gets or sets the item price.</summary>
        /// <value>The item price.</value>
        public decimal ItemPrice { get; set; }

        /// <summary>Gets or sets the valid from.</summary>
        /// <value>The valid from.</value>
        public DateTime ValidFrom { get; set; } = DateTime.UtcNow;

        /// <summary>Gets or sets the valid to.</summary>
        /// <value>The valid to.</value>
        public DateTime? ValidTo { get; set; }

        /// <summary>Gets or sets the item identifier.</summary>
        /// <value>The item identifier.</value>
        public int ItemId { get; set; }
    }
}
