using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public interface ICategoryRepository
    {
        Task<ActionResult<List<Category>>> GetAll();
        Task<ActionResult<Category>> Add(Category category);
    }
}