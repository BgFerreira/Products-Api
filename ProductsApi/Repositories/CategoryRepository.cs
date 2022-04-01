using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;
        
        public CategoryRepository(DataContext context) => _context = context;
        
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<ActionResult<Category>> Add(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            var categoryAdded = _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == category.Id);
            return await categoryAdded;
        }
    }
}