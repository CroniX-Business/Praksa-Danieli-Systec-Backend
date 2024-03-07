// <copyright file="ItemDto.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

namespace OrdersApi.Dto
{
    /// <summary>Object transfer data class for Item.</summary>
    /// <seealso cref="BaseDto" />
    public class ItemDto : BaseDto
    {
        /// <summary>Gets or sets the restaurant identifier.</summary>
        /// <value>The restaurant identifier.</value>
        public int RestaurantId { get; set; }

        /// <summary>Gets or sets the category identifier.</summary>
        /// <value>The category identifier.</value>
        public int CategoryId { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public required string Name { get; set; }

        /// <summary>Gets or sets the sort.</summary>
        /// <value>The sort.</value>
        public int Sort { get; set; }
    }
}
