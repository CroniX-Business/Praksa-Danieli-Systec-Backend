// <copyright file="CustomerDTO.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using WebApplication2.Entities;

namespace WebApplication2.DTO
{
    /// <summary>
    /// Class for Data transfer object of Customer.
    /// </summary>
    public class CustomerDTO : BaseDTO
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public required string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public required string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the order item.
        /// </summary>
        /// <value>
        /// The order item.
        /// </value>
        public List<OrderItem>? OrderItem { get; set; }
    }
}