using MBBE.Dtos.Product;
using MBBE.Interfaces;
using MBBE.Mappers;
using MBBE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MBBE.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]

        public IActionResult GetProducts() {
            var products = _productRepository.GetProducts();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(products);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] CreateStockRequestDto productRequestDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var products = productRequestDto.ToProductFromDto();
            await _productRepository.CreateProductAsync(products);
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
                return NotFound(product);
            return Ok(product);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProductById([FromRoute] Guid id, [FromBody] UpdateStockRequestDto updateStockRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = await _productRepository.UpdateProductAsync(id, updateStockRequestDto);
            if (product == null)
                return NotFound(product);
            return Ok(product);
        }
    }
}
