// <copyright file="PriceDTO.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

// Ignore Spelling: DTO
namespace WebApplication2.DTO
{
    /// <summary>DTO Class for Price.</summary>
    public class PriceDTO : BaseDTO
    {
        /// <summary>Gets or sets the item price.</summary>
        /// <value>The item price.</value>
        public decimal ItemPrice { get; set; }

        /// <summary>Gets or sets the valid from.</summary>
        /// <value>The valid from.</value>
        public DateTime ValidFrom { get; set; }

        /// <summary>Gets or sets the valid to.</summary>
        /// <value>The valid to.</value>
        public DateTime? ValidTo { get; set; }

        /// <summary>Gets or sets the item identifier.</summary>
        /// <value>The item identifier.</value>
        public int ItemId { get; set; }
    }
}
