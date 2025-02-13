using InentoryManagement.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace InentoryManagement.Api.DataAccess
{
    public class InventoryManagementDbContext : DbContext
    {

        public InventoryManagementDbContext(DbContextOptions<InventoryManagementDbContext> dbContextOptions)
      : base(dbContextOptions)
        {

        }

        public DbSet<Stock> Stocks{ get; set; }
    }
}
