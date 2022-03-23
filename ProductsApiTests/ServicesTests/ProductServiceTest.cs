using System.Collections.Generic;
using FluentAssertions;
using Moq;
using ProductsApi.Models;
using ProductsApi.Repositories;
using ProductsApi.Services;
using Xunit;

namespace ProductsApiTests.ServicesTests
{
    public class ProductServiceTest
    {
        private ProductService _service;
        private Mock<IProductRepository> _repository;

        public ProductServiceTest()
        {
            _repository = new Mock<IProductRepository>();
            _service = new ProductService(_repository.Object);
        }

        [Fact]
        public async void GetAllTest()
        {
            //arrange
            List<Product> products = new List<Product>()
            {
                new()
                {
                    Id = 1,
                    Title = "Produto 1",
                    Description = "Uma descrição qualquer",
                    Price = 3.35,
                    CategoryId = 1
                },

                new()
                {
                    Id = 2,
                    Title = "Produto 2",
                    Description = "Uma descrição qualquer",
                    Price = 3.35,
                    CategoryId = 2
                }
            };
            
            //act
            _repository.Setup(x => x.GetAll()).ReturnsAsync(products);

            var result = await _service.GetAll();

            //assert
            result.Value.Should().BeEquivalentTo(products);
        }

        [Fact]
        public async void GetByIdTest()
        {
            //arrange
            int id = 1;
            Product product = new Product()
            {
                Id = 1, 
                Title = "Produto 1", 
                Description = "Uma descrição qualquer", 
                Price = 3.35, 
                CategoryId = 1
            };
            
            //act
            _repository.Setup(x => x.GetById(id)).ReturnsAsync(product);

            var result = await _service.GetById(id);

            //assert
            result.Value.Should().BeEquivalentTo(product);
        }
        
        [Fact]
        public async void GetByCategoryTest()
        {
            //arrange
            int categoryId = 1;
            List<Product> products = new List<Product>()
            {
                new()
                {
                    Id = 1,
                    Title = "Produto 1",
                    Description = "Uma descrição qualquer",
                    Price = 3.35,
                    CategoryId = 1
                },

                new()
                {
                    Id = 2,
                    Title = "Produto 2",
                    Description = "Uma descrição qualquer",
                    Price = 3.35,
                    CategoryId = 1
                }
            };
            
            //act
            _repository.Setup(x => x.GetByCategory(categoryId)).ReturnsAsync(products);

            var result = await _service.GetByCategory((categoryId));

            //assert
            result.Value.Should().BeEquivalentTo(products);
        }

        [Fact]
        public async void AddTest()
        {
            //arrage
            Product product = new Product()
            {
                Id = 1,
                Title = "Produto 1",
                Description = "Uma descrição qualquer",
                Price = 3.35,
                CategoryId = 1
            };

            //act
            _repository.Setup(x => x.Add(product)).ReturnsAsync(product);

            var result = await _service.Add(product);

            //assert
            result.Value.Should().BeEquivalentTo(product);
        }
    }
}