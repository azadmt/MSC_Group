using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Product;
using ProductCatalog.Domain.Contract;

namespace ProductCatalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost(nameof(CreateProduct))]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            productService.CreateProduct(createProductDto);
            return Ok();
        }
    }
}
