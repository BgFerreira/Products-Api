using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Interfaces
{
    public interface ProductsInterface
    {
        Task<ActionResult<List<Product>>> GetAll();
        Task<ActionResult<Product>> GetById(int id);
        Task<ActionResult<List<Product>>> GetByCategory(int id);
        Task<ActionResult<Product>> Add(Product product);
    }
}