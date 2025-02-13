using Framework.Domain;

namespace ProductCatalog.Domain.Contract.Event
{
    public class ProductActivated : DomainEvent
    {
        public Guid ProductId { get;private set; }

        public ProductActivated(Guid productId)
        {
            ProductId = productId;
        }
    }
}
