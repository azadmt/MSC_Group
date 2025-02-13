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
     ProductCatalogDbContext applicationDbContext;

        public ProductRepository(ProductCatalogDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        public ProductAggregate Get(Guid id)
        {
            return applicationDbContext.Set<ProductAggregate>().Single(x=> x.Id==id);
        }

        public void Save(ProductAggregate aggregate)
        {
            applicationDbContext.Set<ProductAggregate>().Add(aggregate);
            applicationDbContext.SaveChanges();
        }
    }
}
