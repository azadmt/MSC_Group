using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Order
{
    public interface IOrderRepository
    {
        void Save(OrderAggregate order);
        void Update(OrderAggregate order);
        OrderAggregate Get(Guid id);
    }
}
