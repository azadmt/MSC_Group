using Framework.Domain;
using ProductCatalog.Domain.Contract;
using ProductCatalog.Domain.Contract.Event;
using SharedKernel;

namespace ProductCatalog.Domain
{
    public class ProductAggregate : AggregateRoot<Guid>
    {
        public byte[] RowVersion { get; set; }

        private ProductAggregate()
        {

        }
     
        public static ProductAggregate CreateProduct(
           Guid id,
        CreateProductCommand createProductCommand,
           int sequence
           )
        {
            var cCode = new CountryCode(createProductCommand.CountryCode);
            return new ProductAggregate(id,
                 createProductCommand.Name,
                 new Color(createProductCommand.Color_R, createProductCommand.Color_G, createProductCommand.Color_B),
                 new Money(createProductCommand.Price),
                 ProductCode.CreatePrductCode(cCode, sequence),
                 cCode
                 );


        }



        public ProductAggregate(Guid id, string name, Color color, Money price, ProductCode code, CountryCode countryCode)
        {
            Id = id;
            Name = name;
            Color = color;
            Price = price;
            Code = code;
            CountryCode = countryCode;
            AddChanges(new ProductCreatedEvent(
                Id,
                Name,
                Code.Value,
                CountryCode.Value,
                Price.Value,
                Color.Red,
                Color.Blue,
                Color.Green
                ));
        }

        public string Name { get; private set; }
        public Color Color { get; private set; }
        public Money Price { get; private set; }
        public ProductCode Code { get; private set; }
        public CountryCode CountryCode { get; private set; }
    }
}