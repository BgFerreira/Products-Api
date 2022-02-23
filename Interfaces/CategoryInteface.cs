using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Interfaces
{
    public interface CategoryInteface
    { 
        Task<ActionResult<List<Category>>> GetAll();
        Task<ActionResult<Category>> Add();
    }
}