using System;
using MassTransit;
using ProductCatalog.Domain;
using ProductCatalog.Domain.Contract;
using ProductCatalog.Domain.Contract.Event;

namespace ProductCatalog.Application.Product;

public class CreateProductCommandHandler :
Framework.Domain.Application.ICommandHandler<CreateProductCommand>
{
    IProductRepository productRepository;
    IBusControl busControl;
    public CreateProductCommandHandler(IProductRepository productRepository, IBusControl busControl)
    {
        this.productRepository = productRepository;
        this.busControl = busControl;
    }

    public void Handle(CreateProductCommand command)
    {
        var sequence = 1;//get new sequence
        var product = ProductAggregate.CreateProduct(
            Guid.NewGuid(),
           command,
            sequence
            );

        productRepository.Save(product);

        foreach (var domainEvent in product.GetChanges())
        {
          busControl.Publish(domainEvent as ProductCreatedEvent).GetAwaiter().GetResult();
        }

    }


}
