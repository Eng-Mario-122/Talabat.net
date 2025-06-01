using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.core.Entites;
using Talabat.core.ProductSpecs;
using Talabat.core.RepositoryContract;
using Talabat.core.Specifications;

namespace Talabat.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductController(IGenericRepository<Product> ProductRepo )
        {
            _productRepo=ProductRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var spec = new ProductWithBrandAndCategory();
            var Product=await _productRepo.GetAllWithSpecAsync(spec);
            return Ok(Product);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetProduct(int id)
        {
            var spec = new ProductWithBrandAndCategory(id);
            var Products=await _productRepo.GetWithSpecAsync(spec);
            if (Products is null)
            {
                return NotFound();
            }

            return Ok(Products);
        }

    }
}
