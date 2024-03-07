﻿using AutoMapper;
using FluentAssertions;
using OrdersApi.Dto;
using OrdersApi.Entities;

namespace OrdersUnitTests.AutoMapperTests
{
    public class CategoryMapperTests
    {
        private readonly IMapper mapper;
        public CategoryMapperTests()
        {
            mapper = InitializeMapper.Initialize();
        }

        [Fact]
        public void CategoryToCategoryDtoMappingTest()
        {
            var category = new Category()
            {
                Id = 1,
                Name = "Test",
                Sort = 1,
            };

            var categoryDto = mapper.Map<CategoryDto>(category);

            categoryDto.Should().NotBeNull();
            categoryDto.Id.Should().Be(category.Id);
            categoryDto.Name.Should().BeEquivalentTo(category.Name);
            categoryDto.Sort.Should().Be(category.Sort);
        }

        [Fact]
        public void CategoryDtoToCategoryMappingTest()
        {

            var categoryDto = new CategoryDto()
            {
                Id = 1,
                Name = "Test",
                Sort = 1,
            };

            var category = mapper.Map<Category>(categoryDto);

            category.Should().NotBeNull();
            category.Id.Should().Be(categoryDto.Id);
            category.Name.Should().BeEquivalentTo(categoryDto.Name);
            category.Sort.Should().Be(categoryDto.Sort);
        }

    }
}