using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Moq;
using ProductsApi.Models;
using ProductsApi.Repositories;
using ProductsApi.Services;

namespace ProductsApiTests.ServicesTests
{
    public class CategoryServiceTest
    {
        private CategoryService _service;
        private Mock<ICategoryRepository> _repository;

        public CategoryServiceTest()
        {
            _repository = new Mock<ICategoryRepository>();
            _service = new CategoryService(_repository.Object);
        }
        
        [Fact]
        public async void  GetAllTest()
        {
            //arrange
            var categories = new List<Category>()
            {
                new()
                {
                    Id = 1,
                    Title = "Categoria 1"
                },
                
                new()
                {
                    Id = 2,
                    Title = "Categoria 2"
                }
            };
            
            _repository.Setup(x => x.GetAll()).ReturnsAsync(categories);
            
            //act
            var result = await _service.GetAll();

            //assert
            result.Value.Should().BeEquivalentTo(categories);
        }

        [Fact]
        public async void AddTest()
        {
            //arrange
            Category category = new Category()
            {
                Id = 1,
                Title = "Categoria 1"
            };

            //act
            _repository.Setup(x => x.Add(category)).ReturnsAsync(category);

            var result = await _service.Add(category);

            //assert
            result.Value.Should().BeEquivalentTo(category);
        }
    }
}