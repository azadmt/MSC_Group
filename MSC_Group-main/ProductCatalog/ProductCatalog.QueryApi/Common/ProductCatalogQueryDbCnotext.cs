using Microsoft.EntityFrameworkCore;
using ProductCatalog.QueryApi.Model;

namespace ProductCatalog.QueryApi.Common
{
    public class ProductCatalogQueryDbCnotext:DbContext
    {

        public ProductCatalogQueryDbCnotext(DbContextOptions<ProductCatalogQueryDbCnotext> dbContextOptions)
         : base(dbContextOptions)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<InboxMessage> Inbox{ get; set; }
    }
}
