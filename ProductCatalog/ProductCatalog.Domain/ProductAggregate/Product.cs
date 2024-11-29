using Framework.Domain;
using ProductCatalog.Domain.Contract;
using ProductCatalog.Domain.Contract.Event;

namespace ProductCatalog.Domain
{
    public class ProductAggregate : AggregateRoot<Guid>
    {

        public static ProductAggregate Create(CreateProductDto createProductDto)
        {
            var price = new Money(createProductDto.Price);
            var productCode = new ProductCode(createProductDto.Code);
            var productName = createProductDto.Name;
            var color = new Color(createProductDto.Color_B, createProductDto.Color_G, createProductDto.Color_R);
            var weight = Weight.FromGram(createProductDto.Weight);

            return new ProductAggregate(Guid.NewGuid(), price, productCode, color, productName, weight); ;
        }


        private ProductAggregate()
        {

        }

        public ProductAggregate(Guid id, Money price, ProductCode code, Color color, string name, Weight weight) : base(id)
        {
            Price = price;
            Code = code;
            Color = color;
            Name = name;
            Weight = weight;

            AddChanges(new ProductCreated(Id,price.Value,code.Value));
        }

        public Money Price { get; private set; }
        public ProductCode Code { get; private set; }
        public Color Color { get; private set; }
        public string Name { get; private set; }
        public Weight Weight { get; private set; }
        public bool IsActive { get; private set; }

        public void Active()
        {
            IsActive = true;
            AddChanges(new ProductActivated(Id));
        }

        public void DeActive()
        {
            IsActive = false;
            AddChanges(new ProductDeActivated(Id));

        }
    }
}