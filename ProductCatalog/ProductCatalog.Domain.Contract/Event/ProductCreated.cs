using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Domain.Contract.Event
{
    public class ProductCreated : DomainEvent
    {
        public Guid ProductId { get; private set; }

        public ProductCreated(Guid productId, decimal price, string code)
        {
            ProductId = productId;
            Price = price;
            Code = code;
        }

        public decimal Price { get; private set; }
        public string Code { get; private set; }
        public int Color_R { get; set; }
        public int Color_B { get; set; }
        public int Color_G { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
    }

    public class ProductActivated : DomainEvent
    {
        public Guid ProductId { get;private set; }

        public ProductActivated(Guid productId)
        {
            ProductId = productId;
        }
    }


    public class ProductDeActivated : DomainEvent
    {
        public Guid ProductId { get; private set; }

        public ProductDeActivated(Guid productId)
        {
            ProductId = productId;
        }
    }
}
