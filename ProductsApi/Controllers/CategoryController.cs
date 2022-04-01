using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Models;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _service;

        public CategoryController(ICategoryService service) => _service = service;


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            var response = await _service.GetAll();
            return response;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Add([FromBody] Category request)
        {
            var response = await _service.Add(request);
            return response;
        }
    }
}