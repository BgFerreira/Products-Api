using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Services
{
    public class ProductService
    {
        private ProductRepository _repository;
        
        public ProductService(DataContext context) => _repository = new ProductRepository(context);

        
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var products = await _repository.GetAll();
            return products;
        }

        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _repository.GetById(id);
            return product;
        }

        public async Task<ActionResult<List<Product>>> GetByCategory(int id)
        {
            var products = await _repository.GetByCategory(id);
            return products;
        }

        public async Task<ActionResult<Product>> Add(Product product)
        {
            var result = await _repository.Add(product);
            return result;
        }
    }
}