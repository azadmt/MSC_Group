namespace ProductCatalog.Domain.Contract
{
    public class CreateProductDto
    {

        public Guid Id { get; private set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
        public int Color_R { get; set; }
        public int Color_B { get; set; }
        public int Color_G { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }

    }
}