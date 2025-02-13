using Framework.Persistence.Framework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Persistence
{
    public class OrderManagementDbContext : DbContext, IUnitOfWork
    {
        public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public void Commit()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new TransactionalOutboxInterceptor());
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}