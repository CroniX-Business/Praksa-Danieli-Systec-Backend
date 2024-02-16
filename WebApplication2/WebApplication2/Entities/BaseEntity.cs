// <copyright file="BaseEntity.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Entities
{
    /// <summary>
    ///   This is base entity.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>Gets or sets the timestamp.</summary>
        /// <value>The timestamp.</value>
        //[Timestamp]
        //public byte[] TimeStamp { get; set; } = Array.Empty<byte>();

        /// <summary>Gets or sets the created time.</summary>
        /// <value>The created time.</value>
        public DateTime CreatedDate { get; set; }

        /// <summary>Gets or sets the modified date.</summary>
        /// <value>The modified date.</value>
        public DateTime? ModifiedDate { get; set; }
    }
}
