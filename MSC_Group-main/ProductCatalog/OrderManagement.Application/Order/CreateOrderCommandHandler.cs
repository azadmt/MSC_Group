using Framework.Domain.Application;
using OrderManagement.Domain;
using OrderManagement.Domain.Contract;
using OrderManagement.Domain.Order;

namespace OrderManagement.Application.Order
{
    public class CreateOrderCommandHandler :
        ICommandHandler<CreateOrderCommand>
    {
        IOrderRepository repository;

        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(CreateOrderCommand command)
        {
            var order=OrderAggregate.Create(command);
            repository.Save(order);
        }

        public void Handle(ApproveOrderCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
