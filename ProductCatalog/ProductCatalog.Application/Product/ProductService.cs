using ProductCatalog.Domain;
using ProductCatalog.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.Product
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void CreateProduct(CreateProductDto createProductDto)
        {
            var product= ProductAggregate.Create(createProductDto);
            productRepository.Save(product);

        }

        public void Active(Guid productId)
        {
            var product = productRepository.Get(productId);
            product.Active();
            productRepository.Save(product);

        }

        public void DeActive(Guid productId)
        {
            var product = productRepository.Get(productId);
            product.DeActive();
            productRepository.Save(product);
        }
    }
}
