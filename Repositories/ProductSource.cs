using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class ProductSource
    {
        private DataContext _context;
        public ProductSource(DataContext context) => _context = context;

        public async Task<ActionResult<List<Product>>> GetProductsList()
        {
            var products = await _context.Products
                .Include(x => x.Category)
                .ToListAsync();
            return products;
        }

        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<ActionResult<List<Product>>> GetProductsByCategory(int id)
        {
            var products = await _context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .Where(x => x.CategoryId == id)
                .ToListAsync();
            return products;
        }

        public async Task<ActionResult<Product>> SetProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}