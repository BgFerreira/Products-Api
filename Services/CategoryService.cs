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
        private CategoryRespository _respository;
        
        public CategoryService(DataContext context) => _respository = new CategoryRespository(context);
        

        public async Task<ActionResult<List<Category>>> GetAll()
        {
            var categories = await _respository.GetAll();
            return categories;
        }

        public async Task<ActionResult<Category>> Add(Category category)
        {
            var result = await _respository.Add(category);
            return result;
        }
    }
}