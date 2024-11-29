using ProductCatalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Persistence.Product
{
    public class ProductRepository : IProductRepository
    {
        public ProductAggregate Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(ProductAggregate aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
