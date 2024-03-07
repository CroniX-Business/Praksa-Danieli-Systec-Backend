using AutoMapper;
using FluentAssertions;
using OrdersApi;
using OrdersApi.Dto;
using OrdersApi.Entities;

namespace OrdersUnitTests.AutoMapperTest
{
    public static class CategoryMapperTest
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            return mapperConfig.CreateMapper();
        }
    }

    public class CategoryMapperTests
    {
        private readonly IMapper _mapper;

        public CategoryMapperTests()
        {
            _mapper = CategoryMapperTest.Initialize();
        }

        [Fact]
        public void Map_CategoryDto_To_Category()
        {
            var categoryDto = new CategoryDto
            {
                Name = "Test category",
                Sort = 1,
            };

            var category = _mapper.Map<Category>(categoryDto);

            category.Should().NotBeNull();
            category.Name.Should().BeEquivalentTo(categoryDto.Name);
            category.Sort.Should().Be(categoryDto.Sort);
        }

        [Fact]
        public void Map_Category_To_CategoryDto()
        {
            var category = new Category
            {
                Id = 1,
                Name = "Test Category",
                Sort = 1,
            };

            var categoryDto = _mapper.Map<CategoryDto>(category);

            categoryDto.Should().NotBeNull();
            categoryDto.Id.Should().Be(category.Id);
            categoryDto.Name.Should().BeEquivalentTo(category.Name);
            categoryDto.Sort.Should().Be(category.Sort);
        }
    }
}