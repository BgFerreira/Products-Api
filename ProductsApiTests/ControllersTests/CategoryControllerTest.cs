using System.Collections.Generic;
using System.ComponentModel;
using FluentAssertions;
using Moq;
using ProductsApi.Controllers;
using ProductsApi.Models;
using ProductsApi.Services;
using Xunit;

namespace ProductsApiTests.ControllersTests
{
    public class CategoryControllerTest
    {
        private CategoryController _controller;
        private Mock<ICategoryService> _service;

        public CategoryControllerTest()
        {
            _service = new Mock<ICategoryService>();
            _controller = new CategoryController(_service.Object);
        }

        [Fact]
        public async void GetAllTest()
        {
            //arrange
            var categories = new List<Category>()
            {
                new()
                {
                    Id = 1,
                    Title = "Teste 1"
                },

                new()
                {
                    Id = 2,
                    Title = "Teste 2"
                }
            };

            _service.Setup(x => x.GetAll()).ReturnsAsync(categories);
            
            //act
            var result = await _controller.GetAll();

            //assert
            result.Value.Should().BeEquivalentTo(categories);
        }

        [Fact]
        public async void AddTest()
        {
            //arrange
            var category = new Category()
            {
                Id = 1,
                Title = "Teste 1"
            };

            _service.Setup(x => x.Add(category)).ReturnsAsync(category);

            //act
            var result = await _controller.Add(category);

            //assert
            result.Value.Should().BeEquivalentTo(category);
        }
    }
}