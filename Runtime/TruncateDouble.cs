using System;

namespace LongMan.BigDouble
{
    public class TruncateDouble : IFormattable
    {
        public double Number { get; private set; }

        public TruncateDouble(double number)
        {
            Number = number;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "1";

            int expLen = 1;

            if (int.TryParse(format, out int outExp))
                expLen = outExp;

            int expPow = (int)Math.Pow(10, expLen);

            return $"{Math.Truncate(Number * expPow) / expPow}";
        }
    }
}