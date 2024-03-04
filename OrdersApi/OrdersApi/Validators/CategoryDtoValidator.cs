﻿// <copyright file="CategoryDtoValidator.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using FluentValidation;
using OrdersApi.Dto;

namespace OrdersApi.Validators
{
    /// <summary>
    /// Validator for category.
    /// </summary>
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryDtoValidator"/> class.
        /// </summary>
        public CategoryDtoValidator() 
        {
            this.RuleFor(category => category.Name)
                .NotEmpty()
                .Matches(@"^(?!-)[A-Za-z0-9ĆćčČžŽšŠđĐ]+(?:-[A-Za-z0-ĆćčČžŽšŠđĐ'_-]+)*(?<!-)");
            this.RuleFor(category => category.Sort)
                .NotEmpty()
                .InclusiveBetween(1, 9);
        }
    }
}
