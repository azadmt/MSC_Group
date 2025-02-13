


using MassTransit;
using ProductCatalog.Domain.Contract.Event;
using ProductCatalog.QueryApi.Common;
using ProductCatalog.QueryApi.Model;

namespace ProductCatalog.QueryApi.EventHandler
{
    internal class ProductCreatedEventHandler : IConsumer<ProductCreatedEvent>
    {
        ProductCatalogQueryDbCnotext QueryDbCnotext;

        public ProductCreatedEventHandler(ProductCatalogQueryDbCnotext queryDbCnotext)
        {
            QueryDbCnotext = queryDbCnotext;
        }

        public async Task Consume(ConsumeContext<ProductCreatedEvent> context)
        {
            var pEvent = context.Message;
            if (QueryDbCnotext.Inbox.Any(x => x.MessageId == pEvent.Id))
                return;
            var product = new Product
            {
                Id = pEvent.ProductId,
                Code = pEvent.Code,
                Name = pEvent.Name,
                Color_B = pEvent.Color_B,
                Color_G = pEvent.Color_G,
                Color_R = pEvent.Color_R,
                CountryCode = pEvent.CountryCode,
                Price = pEvent.Price

            };

            await QueryDbCnotext.Products.AddAsync(product);
            await QueryDbCnotext.Inbox.AddAsync(new InboxMessage { MessageId = pEvent.Id });

            await QueryDbCnotext.SaveChangesAsync();
        }
    }
}