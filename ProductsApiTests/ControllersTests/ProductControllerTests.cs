using System.Collections.Generic;
using FluentAssertions;
using Moq;
using ProductsApi.Controllers;
using ProductsApi.Models;
using ProductsApi.Services;
using Xunit;

namespace ProductsApiTests.ControllersTests
{
    public class ProductControllerTests
    {
        private ProductController _controller;
        private Mock<IProductService> _service;

        public ProductControllerTests()
        {
            _service = new Mock<IProductService>();
            _controller = new ProductController(_service.Object);
        }

        [Fact]
        public async void GetAllTest()
        {
            //arrange
            var products = new List<Product>()
            {
                new()
                {
                    Id = 1,
                    Title = "Teste 1",
                    Description = "Qualquer coisa",
                    Price = 1.00,
                    CategoryId = 1,
                    Category = null
                },
                
                new()
                {
                    Id = 2,
                    Title = "Teste 2",
                    Description = "Qualquer coisa",
                    Price = 1.00,
                    CategoryId = 1,
                    Category = null
                }
            };

            _service.Setup(x => x.GetAll()).ReturnsAsync(products);

            //act
            var result = await _controller.GetAll();
            
            //assert
            result.Value.Should().BeEquivalentTo(products);
        }

        [Fact]
        public async void GetByIdTest()
        {
            //arrange
            var id = 1;
            
            var product = new Product()
            {
                Id = 1,
                Title = "Teste 1",
                Description = "Qualquer coisa",
                Price = 1.00,
                CategoryId = 1,
                Category = null
            };

            _service.Setup(x => x.GetById(id)).ReturnsAsync(product);

            //act
            var result = await _controller.GetById(id);
            
            //assert
            result.Value.Should().BeEquivalentTo(product);
        }

        [Fact]
        public async void GetByCategoryTest()
        {
            //arrange
            var categoryId = 1;
            
            var products = new List<Product>()
            {
                new()
                {
                    Id = 1,
                    Title = "Teste 1",
                    Description = "Qualquer coisa",
                    Price = 1.00,
                    CategoryId = 1,
                    Category = null
                },
                
                new()
                {
                    Id = 2,
                    Title = "Teste 2",
                    Description = "Qualquer coisa",
                    Price = 1.00,
                    CategoryId = 1,
                    Category = null
                }
            };

            _service.Setup(x => x.GetByCategory(categoryId)).ReturnsAsync(products);
            
            //act
            var result = await _controller.GetByCategory(categoryId);
            
            //assert
            result.Value.Should().BeEquivalentTo(products);
        }

        [Fact]
        public async void AddTest()
        {
            //assert
            var product = new Product()
            {
                Id = 1,
                Title = "Teste 1",
                Description = "Qualquer coisa",
                Price = 1.00,
                CategoryId = 1,
                Category = null
            };

            _service.Setup(x => x.Add(product)).ReturnsAsync(product);
            
            //act
            var result = await _controller.Add(product);
            
            //assert
            result.Value.Should().BeEquivalentTo(product);
        }
    }
}