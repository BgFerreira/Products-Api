using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Services
{
    public class CategoryService
    {
        private CategorySource _source;
        public CategoryService(DataContext context) => _source = new CategorySource(context);

        public async Task<ActionResult<List<Category>>> GetCategoriesList()
        {
            var categories = await _source.GetCategoriesList();
            return categories;
        }

        public async Task<ActionResult<Category>> SetCategory(Category category)
        {
            var result = await _source.SetCategory(category);
            return result;
        }
    }
}