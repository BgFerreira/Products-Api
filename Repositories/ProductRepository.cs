using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class ProductRepository
    {
        private DataContext _context;
        
        public ProductRepository(DataContext context) => _context = context;

        
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var products = await _context.Products
                .Include(x => x.Category)
                .ToListAsync();
            return products;
        }

        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<ActionResult<List<Product>>> GetByCategory(int id)
        {
            var products = await _context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .Where(x => x.CategoryId == id)
                .ToListAsync();
            return products;
        }

        public async Task<ActionResult<Product>> Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            var productAdded = _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == product.Id);
            return await productAdded;
        }
    }
}