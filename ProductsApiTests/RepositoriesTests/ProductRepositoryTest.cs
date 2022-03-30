using System;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;
using ProductsApi.Repositories;
using Xunit;

namespace ProductsApiTests.RepositoriesTests
{
    public class ProductRepositoryTest
    {
        private ProductRepository _repository;
        private DataContext _context;

        public ProductRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            
            _context = new DataContext(options);
            _repository = new ProductRepository(_context);
        }

        private async void PopulateDbContext()
        {
            if (await _context.Categories.CountAsync() <= 0)
            {
                for (int i = 1; i <= 3; i++)
                { 
                    _context.Categories.Add(new Category() 
                    {
                        Id = i, 
                        Title = $"Categoria {i}"
                    });
                }
                
                await _context.SaveChangesAsync();
            }
            
            if (await _context.Products.CountAsync() <= 0)
            {
                for (int i = 1; i <=3; i++)
                {
                    _context.Products.Add(new Product()
                    {
                        Id = i,
                        Title = $"Product {i}",
                        Description = "Anything",
                        Price = 1.00,
                        CategoryId = i,
                        Category = null
                    });
                }

                await _context.SaveChangesAsync();
            }
        }

        [Fact]
        private async void GetAllTest()
        {
            //arrange
            PopulateDbContext();
            
            var products = await _context.Products
                .Include(x => x.Category)
                .ToListAsync();
            
            //act
            var result = await _repository.GetAll();

            //assert
            result.Value.Should().BeEquivalentTo(products);
        }

        [Fact]
        private async void GetByIdTest()
        {
            //arrange
            PopulateDbContext();

            var id = 1;
            var product = await _context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            //act
            var result = await _repository.GetById(id);

            //assert
            result.Value.Should().BeEquivalentTo(product);
        }

        [Fact]
        private async void GetByCategoryTest()
        {
            //arrange
            PopulateDbContext();

            var categoryId = 1;
            var product = await _context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();
            
            //act
            var result = await _repository.GetByCategory(categoryId);

            //assert
            result.Value.Should().BeEquivalentTo(product);
        }

        [Fact]
        private async void AddTest()
        {
            //arrange
            var product = new Product()
            {
                Id = 1,
                Title = $"Product 1",
                Description = "Anything",
                Price = 1.00,
                CategoryId = 1,
                Category = null
            };
            
            //act
            var result = await _repository.Add(product);
            
            //assert
            result.Value.Should().BeEquivalentTo(product);
        }
    }
}