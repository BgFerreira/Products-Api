using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using ProductsApi.Data;
using ProductsApi.Models;
using ProductsApi.Repositories;
using Xunit;

namespace ProductsApiTests.RepositoriesTests
{
    public class CategoryRepositoryTest
    {
        private CategoryRepository _repository;
        private DataContext _context;
        //private Mock<DbSet<Category>> _dbSet;

        public CategoryRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new DataContext(options);
            _repository = new CategoryRepository(_context);
            //_dbSet = new Mock<DbSet<Category>>();
        }

        [Fact]
        public async void GetAllTest()
        {
            //arrange
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
            
            var categories = await _context.Categories.ToListAsync();

            //act
            var result = await _repository.GetAll();

            //assert
            result.Value.Should().BeEquivalentTo(categories);
        }
    }
}