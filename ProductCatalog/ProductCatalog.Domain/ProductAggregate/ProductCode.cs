using Framework.Domain;

namespace ProductCatalog.Domain
{
    public class ProductCode:ValueObject
    {
        public string Value { get; private set; }
        public ProductCode(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Count() > 10)
                throw new ArgumentException("value");

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityAttribute()
        {
           yield return Value;
        }
    }
}