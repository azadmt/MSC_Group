using InentoryManagement.Api.DataAccess;
using InentoryManagement.Api.Model;
using InventoryManagement.Contract;
using MassTransit;
using OrderManagement.Domain.Contract.Event;

namespace InentoryManagement.Api.EventHandler
{
    internal class OrderCreatedEventHandler : IConsumer<OrderCreatedEvent>
    {
        InventoryManagementDbContext dbContext;

        public OrderCreatedEventHandler(InventoryManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            //TODO implement InboxPattern
           
            var orderEvent = context.Message;
            var productsId = orderEvent.OrderItems.Select(x => x.ProductId).ToList();
            var stocks = dbContext.Set<Stock>().Where(x => productsId.Contains(x.ProductId)).ToList();
            foreach (var item in stocks)
            {
                var orderLine = orderEvent.OrderItems.FirstOrDefault(x => x.ProductId == item.ProductId);
                if (item.Quantity < orderLine.Quantity)
                {
                    await context.Publish(new StockAdjusmentRejectedEvent() { OrderId = orderEvent.OrderId });
                    return;
                }
                else
                {
                    item.Quantity -= orderLine.Quantity;
                }
            }
            dbContext.Set<Stock>().UpdateRange(stocks);
            dbContext.SaveChanges();
            await context.Publish(new StockAdjusmentConfirmedEvent() { OrderId = orderEvent.OrderId });

        }
    }
}
