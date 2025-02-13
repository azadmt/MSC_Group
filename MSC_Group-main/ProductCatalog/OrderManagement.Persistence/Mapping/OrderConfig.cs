using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain;

namespace OrderManagement.Persistence.Mapping
{
    public  class OrderConfig : IEntityTypeConfiguration<OrderAggregate>
    {
        public void Configure(EntityTypeBuilder<OrderAggregate> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=> x.CustomerId);
            builder.Property(x=> x.OrderDate);

            //builder.OwnsMany(x => x.OrderItems);
            builder.OwnsMany(x => x.OrderItems,b=>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.ProductId);
                b.Property(x => x.Quantity);
                b.OwnsOne(x => x.UnitPrice);

            });

            builder.Property(x => x.State)
              .HasConversion(
              p => p.GetType().Name,
              p => GetOrderState(p)
              );

            builder
                .Metadata
                .FindNavigation(nameof(OrderAggregate.OrderItems))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            //builder.OwnsMany(x => x.OrderItems, b =>
            //{            
            //    b.HasKey(x => x.Id);
            //    b.Property(x => x.ProductId);
            //    b.OwnsOne(x => x.Quantity);
            //    b.OwnsOne(x => x.UnitPrice);
            //});
        }

        public OrderState GetOrderState(string state)
        {
            return state switch
            {
                nameof(PendingState) => new PendingState(),
                nameof(CancelledState) => new CancelledState(),
                nameof(ApprovedState) => new ApprovedState(),
                nameof(DeliveredState) => new DeliveredState(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
