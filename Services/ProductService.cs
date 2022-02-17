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
        private ProductSource _source;
        public ProductService(DataContext context) => _source = new ProductSource(context);

        public async Task<ActionResult<List<Product>>> GetProductList()
        {
            var products = await _source.GetProductsList();
            return products;
        }

        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _source.GetProductById(id);
            return product;
        }

        public async Task<ActionResult<List<Product>>> GetProductsByCategory(int id)
        {
            var products = await _source.GetProductsByCategory(id);
            return products;
        }

        public async Task<ActionResult<Product>> SetProduct(Product product)
        {
            var result = await _source.SetProduct(product);
            return result;
        }
    }
}