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
        private Mock<DataContext> _context;

        public CategoryRepositoryTest()
        {
            var options = new DbContextOptions<DataContext>();
            _context = new Mock<DataContext>(options);
            _repository = new CategoryRepository(_context.Object);
        }

        [Fact]
        public async void GetAllTest()
        {
            //arrange
            var category = new Category()
            {
                Id = 1,
                Title = "teste"
            };
            
            var categoriesMock = new Mock<IDataContext>();
            var categoriesAddMock = new Mock<DbSet<Category>>();
            categoriesAddMock.Setup(x => x.Add(It.IsAny<Category>())).Returns(It.IsAny<EntityEntry<Category>>());
            categoriesMock.Setup(x => x.Categories).Returns(categoriesAddMock.Object);

            //var fakeDbSet = new FakeDbSet<Category>();



            //act
            var result = categoriesMock.Object.Categories.Add((category));

            //assert
            categoriesAddMock.Verify(x => x.Add(category), Times.Exactly(1));
        }
    }
}