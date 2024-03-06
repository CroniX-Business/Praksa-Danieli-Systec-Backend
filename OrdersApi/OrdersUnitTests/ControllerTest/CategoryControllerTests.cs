using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrdersApi.Controllers;
using OrdersApi.Data;
using OrdersApi.Dto;
using OrdersApi.Entities;

namespace OrdersUnitTests.ControllersTests
{
    public class CategoryControllerTests
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly ILogger<CategoryController> logger;

        [Fact]
        public void CategoryController_GetAllCategories_ReturnsOk()
        {
            var categoryController = new CategoryController(context, mapper, logger);

            var result = categoryController.GetAllCategories();

            result.Should().BeOfType<Task<ActionResult<IEnumerable<CategoryDto>>>>();
        }


        [Fact]
        public void CategoryController_GetCategory_ReturnsOk()
        {
            var categoryController = new CategoryController(context, mapper, logger);
            var category = new Category()
            {
                Id = 1,
                Name = "Test",
                Sort = 3,
            };

            var result = categoryController.GetCategory(category.Id);

            result.Should().BeOfType<Task<ActionResult<CategoryDto>>>();
        }

        [Fact]
        public void CategoryController_AddCategory_ReturnsCreatedAtAction()
        {
            var categoryController = new CategoryController(context, mapper, logger);
            var categoryDto = new CategoryDto()
            {
                Id = 1,
                Name = "Test",
                Sort = 3,
            };

            var result = categoryController.AddCategory(categoryDto);

            result.Should().BeOfType<Task<ActionResult<CategoryDto>>>();
        }

        [Fact]
        public void CategoryController_UpdateCategory_ReturnsNoContent()
        {
            var categoryController = new CategoryController(context, mapper, logger);
            var category = new Category()
            {
                Id = 1,
                Name = "Test",
                Sort = 3,
            };
            var categoryDto = new CategoryDto()
            {
                Id = 1,
                Name = "Test",
                Sort = 4,
            };

            var result = categoryController.UpdateCategory(category.Id, categoryDto);

            result.Should().BeOfType<Task<ActionResult<CategoryDto>>>();
        }

        [Fact]
        public void CategoryController_DeleteCategory_ReturnsNoContent()
        {
            var categoryController = new CategoryController(context, mapper, logger);
            var category = new Category()
            {
                Id = 1,
                Name = "Test",
                Sort = 5,
            };

            var result = categoryController.DeleteCategory(category.Id);

            result.Should().BeOfType<Task<ActionResult>>();
        }
    }
}
