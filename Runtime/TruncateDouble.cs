using System;
using System.Globalization;

namespace LongMan.BigDouble
{
    public class TruncateDouble : IFormattable
    {
        public string NumberStr { get; }

        public TruncateDouble(string numberStr)
        {
            NumberStr = numberStr;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "1";

            int expLen = 1;

            if (int.TryParse(format, NumberStyles.Number, CultureInfo.InvariantCulture, out int outExp))
                expLen = outExp;

            int pointIndex = NumberStr.IndexOf('.');

            // No Point ( 정수 )
            if (pointIndex < 0)
                return NumberStr;

            // Have Point ( 소수 )
            string[] pointSplit = NumberStr.Split('.');
            string pointAfterString = pointSplit[1].Substring(0, Math.Min(expLen, pointSplit[1].Length));

            return $"{pointSplit[0]}.{pointAfterString}";
        }
    }
}