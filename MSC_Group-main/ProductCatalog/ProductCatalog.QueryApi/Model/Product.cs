using System;

namespace ProductCatalog.QueryApi.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CountryCode { get; set; }
        public decimal Price { get; set; }
        public byte Color_R { get; set; }
        public byte Color_B { get; set; }
        public byte Color_G { get; set; }
    }

    public class InboxMessage
    {
        public Guid MessageId { get; set; }
    }
}
