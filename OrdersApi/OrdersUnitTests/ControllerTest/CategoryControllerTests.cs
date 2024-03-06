using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrdersApi.Controllers;
using OrdersApi.Data;
using OrdersApi.Dto;

namespace OrdersUnitTests.ControllerTest
{
    public class CategoryControllerTests
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly ILogger<CategoryController> logger;

        [Fact]
        public void GetAllTest()
        {
            var controller = new CategoryController(context, mapper, logger);

            var result = controller.GetAllCategories();

            result.Should().BeOfType<Task<ActionResult<IEnumerable<CategoryDto>>>>();
        }
        [Fact]
        public void GetCategoryTest()
        {
            var controller = new CategoryController(context, mapper, logger);

            var result = controller.GetCategory(1);

            result.Should().BeOfType<Task<ActionResult<CategoryDto>>>();
        }

        [Fact]
        public void AddCategoryTest()
        {
            var controller = new CategoryController(context, mapper, logger);

            var category = new CategoryDto
            {
                Name = "TestCategory",
                Sort = 1,
            };

            var result = controller.AddCategory(category);

            result.Should().BeOfType<Task<ActionResult<CategoryDto>>>();

        }
        [Fact]
        public void UpdateCategoryTest()
        {
            var controller = new CategoryController(context, mapper, logger);

            var category = new CategoryDto
            {
                Id = 1,
                Name = "TestCategory",
                Sort = 1,
            };

            var newCategory = new CategoryDto
            {
                Id = 1,
                Name = "NewCategory",
                Sort = 2,
            };

            controller.AddCategory(category);

            var result = controller.UpdateCategory(category.Id, newCategory);

            result.Should().BeOfType<Task<ActionResult<CategoryDto>>>();
        }

        [Fact]
        public void DeleteCategoryTest()
        {
            var controller = new CategoryController(context, mapper, logger);

            var result = controller.DeleteCategory(1);

            result.Should().BeOfType<Task<ActionResult>>();
        }
    }
}
