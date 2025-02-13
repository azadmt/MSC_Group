using Framework.Domain;

namespace ProductCatalog.Domain.Contract.Event
{
    public class ProductDeActivated : DomainEvent
    {
        public Guid ProductId { get; private set; }

        public ProductDeActivated(Guid productId)
        {
            ProductId = productId;
        }
    }
}
