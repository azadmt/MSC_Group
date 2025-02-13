using Framework.Domain.Application;
using OrderManagement.Domain.Contract;
using OrderManagement.Domain.Order;

namespace OrderManagement.Application.Order
{
    public class ApproveOrderCommandHandler : ICommandHandler<ApproveOrderCommand>
    {
        IOrderRepository repository;

        public ApproveOrderCommandHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(ApproveOrderCommand command)
        {
            var order= repository.Get(command.Id);
            order.Approve();
            repository.Update(order);
        }


    }
}
