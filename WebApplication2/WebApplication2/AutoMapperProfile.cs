﻿// <copyright file="AutoMapperProfile.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using AutoMapper;
using WebApplication2.DTO;
using WebApplication2.Entities;

namespace WebApplication2
{
    /// <summary>Class for AutoMapper.</summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>Initializes a new instance of the <see cref="AutoMapperProfile" /> class.</summary>
        public AutoMapperProfile()
        {
            this.CreateMap<Restaurant, RestaurantDTO>().ReverseMap();
            this.CreateMap<Category, CategoryDTO>().ReverseMap();
            this.CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
