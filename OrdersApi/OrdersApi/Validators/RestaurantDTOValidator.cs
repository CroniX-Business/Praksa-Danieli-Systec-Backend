// <copyright file="RestaurantDTOValidator.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using FluentValidation;
using OrdersApi.DTO;

namespace OrdersApi.Validators
{
    public class RestaurantDTOValidator : AbstractValidator<RestaurantDTO>

    {
        public RestaurantDTOValidator()
        {
            this.RuleFor(restaurant => restaurant.Name).NotEmpty().Matches(@"^(?!-)[A-Za-z0-9]+(?:-[A-Za-z0-9'_-]+)*(?<!-)$");
            this.RuleFor(restaurant => restaurant.Address).NotEmpty().Matches(@"^(?:[A-Za-z0-9]+(?:-[A-Za-z0-9'_-]+)*|\s*)+$");
            this.RuleFor(restaurant => restaurant.PhoneNumber).NotEmpty().Matches(@"^\+?[0-9]+\/?[0-9]{5,15}$");
        }
    }
}
