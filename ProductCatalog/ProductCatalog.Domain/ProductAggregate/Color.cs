using Framework.Domain;

namespace ProductCatalog.Domain
{
    public class Color : ValueObject
    {
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }
        public Color(int blue, int green, int red)
        {
            if (blue < 0 || blue > 255)
                throw new ArgumentOutOfRangeException();
            Blue = blue;

            if (green < 0 || green > 255)
                throw new ArgumentOutOfRangeException();
            Green = green;

            if (red < 0 || red > 255)
                throw new ArgumentOutOfRangeException();
            Red = red;
        }

        protected override IEnumerable<object> GetEqualityAttribute()
        {
            
            yield return Red;
            yield return Green;
            yield return Blue;
        }
    }
}