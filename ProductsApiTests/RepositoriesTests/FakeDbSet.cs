using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace ProductsApiTests.RepositoriesTests
{
    public class FakeDbSet<T> : DbSet<T> where T : class
    {
        public override EntityEntry<T> Add(T entity)
        {
            return It.IsAny<EntityEntry<T>>();
        }
    }
}