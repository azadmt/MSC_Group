using System.Windows.Input;

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

    public class ActiveProductCommand:Framework.Domain.Application.ICommand
    {

        public Guid Id { get;  set; }
    }

    public class CreateProductCommand : Framework.Domain.Application.ICommand
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public decimal Price { get; set; }
        public byte Color_R { get; set; }
        public byte Color_B { get; set; }
        public byte Color_G { get; set; }
    }
}