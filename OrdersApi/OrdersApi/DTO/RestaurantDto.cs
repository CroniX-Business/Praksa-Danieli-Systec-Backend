// <copyright file="RestaurantDto.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

namespace OrdersApi.Dto
{
    /// <summary>Data transfer object for restaurant.</summary>
    /// <seealso cref="BaseDto" />
    public class RestaurantDto : BaseDto
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public required string Name { get; set; }

        /// <summary>Gets or sets the address.</summary>
        /// <value>The address.</value>
        public required string Address { get; set; }

        /// <summary>Gets or sets the telephone number.</summary>
        /// <value>The telephone number.</value>
        public required string PhoneNumber { get; set; }
    }
}
