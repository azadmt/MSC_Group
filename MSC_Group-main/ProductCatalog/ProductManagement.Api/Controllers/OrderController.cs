using Framework.Domain.Application;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Domain.Contract;

namespace ProductManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        ICommandBus commandBus;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, ICommandBus commandBus)
        {
            _logger = logger;
            this.commandBus = commandBus;
        }

        [HttpPost(nameof(CreateOrder))]
        public IActionResult CreateOrder(CreateOrderCommand command)
        {
            commandBus.Send(command);
            return Ok();
        }


        [HttpPost(nameof(Approve))]
        public IActionResult Approve(ApproveOrderCommand command)
        {
            commandBus.Send(command);
            return Ok();
        }
    }
}