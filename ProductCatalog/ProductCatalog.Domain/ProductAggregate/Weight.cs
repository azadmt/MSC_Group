using Framework.Domain;

namespace ProductCatalog.Domain
{
    public class Weight:ValueObject
    {
  
        public static Weight FromGram(int gramValue)
        {
            return new Weight (gramValue);
        }

        protected override IEnumerable<object> GetEqualityAttribute()
        {
            return new object[] { Value };
           
        }

        public int Value { get; private set; }

        public Weight(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("value");
            Value = value;
        }
    }
}