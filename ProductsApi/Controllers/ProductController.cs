using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Models;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        private ProductService _service;
        
        public ProductController([FromServices] DataContext context) => _service = new ProductService(context);


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var response = await _service.GetAll();
            return response;
        }

        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var response = await _service.GetById(id);
            return response;
        }

        
        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] DataContext context, int id)
        {
            var response = await _service.GetByCategory(id);
            return response;
        }

        
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.Add(product);
            return response;
        }
    }
}