 using Microsoft.EntityFrameworkCore;
 using ProductsApi.Models;

 namespace ProductsApi.Data
 {
     public interface IDataContext : IDbContext
     {
         public DbSet<Category> Categories { get; set; }
         public DbSet<Product> Products { get; set; }
     }
}