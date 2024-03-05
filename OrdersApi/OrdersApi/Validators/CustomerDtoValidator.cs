// <copyright file="CustomerDtoValidator.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using FluentValidation;
using OrdersApi.Dto;

namespace OrdersApi.Validators
{
    /// <summary>Customer validator.</summary>
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        /// <summary>Initializes a new instance of the <see cref="CustomerDtoValidator" /> class.</summary>
        public CustomerDtoValidator()
        {
            this.RuleFor(customer => customer.FirstName)
                .NotEmpty()
                .Matches(@"^(?:[A-Za-zČčĆćĐđŠšŽž0-9]+(?:-[A-Za-zČčĆćĐđŠšŽž0-9'_-]+)*|\s*)+$");
            this.RuleFor(customer => customer.LastName)
                .NotEmpty()
                .Matches(@"^(?:[A-Za-zČčĆćĐđŠšŽž0-9]+(?:-[A-Za-zČčĆćĐđŠšŽž0-9'_-]+)*|\s*)+$");
            this.RuleFor(customer => customer.PhoneNumber)
                .NotEmpty()
                .Matches(@"^\+?[0-9]+\/?[0-9]$")
                .Length(5, 15);
        }
    }
}
