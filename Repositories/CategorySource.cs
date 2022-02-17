using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class CategorySource
    {
        private DataContext _context;
        public CategorySource(DataContext context) => _context = context;
        
        public async Task<ActionResult<List<Category>>> GetCategoriesList()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<ActionResult<Category>> SetCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}