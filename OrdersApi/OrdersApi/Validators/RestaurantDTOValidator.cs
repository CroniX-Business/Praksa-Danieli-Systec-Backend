﻿// <copyright file="RestaurantDTOValidator.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using FluentValidation;
using OrdersApi.Dto;

namespace OrdersApi.Validators
{
    /// <summary>Restaurant validator class.</summary>
    public class RestaurantDtoValidator : AbstractValidator<RestaurantDto>
    {
        /// <summary>Initializes a new instance of the <see cref="RestaurantDtoValidator" /> class.</summary>
        public RestaurantDtoValidator()
        {
            this.RuleFor(restaurant => restaurant.Name).NotEmpty()
                .Matches(@"^(?!-)[A-Za-z0-9ĆćčČžŽšŠđĐ]+(?:-[A-Za-z0-ĆćčČžŽšŠđĐ'_-]+)*(?<!-)");
            this.RuleFor(restaurant => restaurant.Address).NotEmpty()
                .Matches(@"^(?!-)[A-Za-z0-9ĆćčČžŽšŠđĐ]+(?:-[A-Za-z0-ĆćčČžŽšŠđĐ'_-]+)*(?<!-)");
            this.RuleFor(restaurant => restaurant.PhoneNumber).NotEmpty()
                .Matches(@"^\+?[0-9]+\/?[0-9]$")
                .Length(5, 15);
        }
    }
}
