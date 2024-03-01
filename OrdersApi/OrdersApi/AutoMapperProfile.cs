// <copyright file="AutoMapperProfile.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using AutoMapper;
using OrdersApi.Dto;
using OrdersApi.Entities;

namespace OrdersApi
{
    /// <summary>Represents a profile of Auto mapper.</summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>Initializes a new instance of the <see cref="AutoMapperProfile" /> class.</summary>
        public AutoMapperProfile()
        {
            this.CreateMap<Restaurant, RestaurantDto>()
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());
            this.CreateMap<Category, CategoryDto>()
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());
            this.CreateMap<Customer, CustomerDto>()
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
