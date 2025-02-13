using Framework.Domain.Application;

namespace OrderManagement.Domain.Contract
{
    public class ApproveOrderCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}