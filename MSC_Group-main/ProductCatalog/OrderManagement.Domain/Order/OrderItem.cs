using Framework.Domain;
using SharedKernel;

namespace OrderManagement.Domain
{
    public class OrderItem : Entity<Guid>
    {
        public Money UnitPrice { get; private set; }

        public OrderItem(Guid id, Money unitPrice, uint quantity, Guid productId)
        {
            Id= id;
            UnitPrice = unitPrice;
            Quantity = quantity;
            ProductId = productId;
        }

        //ORM Useage
        private OrderItem()
        {

        }
        public uint Quantity { get; private set; }
        public Guid ProductId { get; private set; }


    }

}