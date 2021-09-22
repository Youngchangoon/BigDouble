using System;

namespace LongMan.BigDouble
{
    public class TruncateExp : IFormattable
    {
        public double Number { get; private set; }
        
        public TruncateExp(double number)
        {
            Number = number;
        }
        
        public string ToString(string format, IFormatProvider formatProvider)
        {
            int numLength = (int)Math.Log10(Number);

            string numStr = Number.ToString("0");
            numStr = numStr.Insert(1, ".").TrimEnd('0');

            return $"{numStr}e+{numLength}";
        }
    }
}