using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _respository;
        
        public CategoryService(ICategoryRepository repository) => _respository = repository;
        

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