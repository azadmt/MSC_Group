using Framework.Domain.Application;
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

      //  private ProductService productService;
      ICommandBus commandBus;

        public ProductController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }


        // public ProductController(ProductService productService)
        // {
        //     this.productService = productService;
        // }

        [HttpPost(nameof(CreateProduct))]
        public IActionResult CreateProduct(CreateProductCommand command)
        {
            commandBus.Send(command);
            return Ok();
        }

            [HttpPost(nameof(Active))]
        public IActionResult Active(ActiveProductCommand command)
        {
            commandBus.Send(command);
            return Ok();
        }
    }
}
