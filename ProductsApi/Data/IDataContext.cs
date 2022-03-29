 using Microsoft.EntityFrameworkCore;
 using ProductsApi.Models;

 namespace ProductsApi.Data
 {
     public interface IDataContext
     {
         public DbSet<Category> Categories { get; set; }
         public DbSet<Product> Products { get; set; }
     }
}