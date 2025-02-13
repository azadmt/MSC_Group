namespace ProductCatalog.Domain
{
    public interface IProductRepository
    {
        ProductAggregate Get(Guid id);
        void Save(ProductAggregate aggregate);
        
    }
}