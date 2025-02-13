using Framework.Domain;
using OrderManagement.Domain.Contract;
using OrderManagement.Domain.Contract.Event;
using SharedKernel;

namespace OrderManagement.Domain
{
    public class OrderAggregate : AggregateRoot<Guid>
    {


        public static OrderAggregate Create(CreateOrderCommand createOrderCommand)
        {

            var ag = new OrderAggregate();

            ag.Id = Guid.NewGuid();
            ag.OrderDate = DateTime.Now;

            ag.CustomerId = createOrderCommand.CustomerId;
            ag.State = new PendingState();
            if (!createOrderCommand.OrderItems.Any())
            {
                throw new CanNotCreateOrderWithoutOrderItemsException();
            }
            foreach (var item in createOrderCommand.OrderItems)
            {
                ag._orderItems.Add(new OrderItem(
                    Guid.NewGuid(),
                    new Money(item.UnitPrice),
                    item.Quantity,
                    item.ProductId
                    ));
            }
            var orderCreatedEvent = new OrderCreatedEvent(
                ag.Id,
                ag.OrderDate,
                ag.OrderItems.Select(x => new OrderItemDto { ProductId = x.ProductId, UnitPrice = x.UnitPrice.Value }).ToList());
            ag.AddChanges(orderCreatedEvent);
            return ag;
        }
        public OrderAggregate()
        {

        }

        public Guid CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }

        protected List<OrderItem> _orderItems = new();
        public IEnumerable<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public OrderState State { get; set; }
        public void Approve()
        {
            //if (State != OrderState.Pending)
            //    throw new InvalidOperationException();

            State = State.Approved();
            AddChanges(new OrderApprovedEvent(Id));

        }


        public void Cancele()
        {
            //if (State != OrderState.Approved || State != OrderState.Pending)
            //    throw new InvalidOperationException();

            State = State.Cancelled();
        }

        public void Deliver()
        {
            State = State.Delivered();

        }
        public void AddItems(OrderItem orderItem)
        {
            if (_orderItems.Sum(x => x.UnitPrice.Value) > 2_000_000_000)
                throw new InvalidOperationException();
            _orderItems.Add(orderItem);
        }
        //protected OrderAggregate()
        //{

        //}
    }

}

public abstract class OrderState
{
    public virtual OrderState Pending() => throw new NotSupportedException();
    public virtual OrderState Cancelled() => throw new NotSupportedException();
    public virtual OrderState Approved() => throw new NotSupportedException();
    public virtual OrderState Delivered() => throw new NotSupportedException();

}

public class PendingState : OrderState
{
    public override OrderState Cancelled()
    {
        return new CancelledState();
    }

    public override OrderState Approved()
    {
        return new ApprovedState();
    }
}

public class CancelledState : OrderState
{

}

public class ApprovedState : OrderState
{
    public override OrderState Cancelled()
    {
        return new CancelledState();
    }
}


public class DeliveredState : OrderState
{

}