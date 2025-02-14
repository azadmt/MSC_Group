using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Contract.Event
{
    public  class OrderCreatedEvent : DomainEvent
    {
        public OrderCreatedEvent(Guid orderId,DateTime orderDate,List<OrderItemDto> orderItemDtos)
        {
            OrderId=orderId;    
            OrderDate=orderDate;
            OrderItems=orderItemDtos;
        }

        [JsonConstructor]
        private OrderCreatedEvent()
        {

        }

        [JsonInclude]
        public Guid OrderId { get;private set; }

        [JsonInclude]
        public DateTime OrderDate { get; private set; }
        [JsonInclude]
        public List<OrderItemDto> OrderItems { get; private set; }
    }

    public class OrderApprovedEvent : DomainEvent
    {
        public OrderApprovedEvent(Guid orderId)
        {
            OrderId = orderId;
        }
        public Guid OrderId { get; private set; }

    }


}
