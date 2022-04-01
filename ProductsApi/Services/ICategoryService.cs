using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Services
{
    public interface ICategoryService
    {
       Task<ActionResult<List<Category>>> GetAll();
       Task<ActionResult<Category>> Add(Category category);
    }
}