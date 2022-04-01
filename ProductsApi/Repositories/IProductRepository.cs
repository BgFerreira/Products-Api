using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public interface IProductRepository
    {
        Task<ActionResult<List<Product>>> GetAll();
        Task<ActionResult<Product>> GetById(int id);
        Task<ActionResult<List<Product>>> GetByCategory(int id);
        Task<ActionResult<Product>> Add(Product product);
    }
}