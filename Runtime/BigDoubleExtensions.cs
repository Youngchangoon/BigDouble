using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace LongMan.BigDouble
{
    public static class BigDoubleExtensions
    {
        public static KeyValuePair<string, BigDoubleInfo> CurDoublePair;

        /// <summary>
        /// 지수표기법으로 되어있는 double도 모두 0과 콤마로 풀어 쓴다.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string DoubleToFullString(this double number)
        {
            return number.ToString("n0");
        }

        /// <summary>
        /// double을 사전에 정의된 단위로 변환해서 보여준다.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string DoubleToShortString(this double number)
        {
            if (CurDoublePair.Value == null)
                CurDoublePair = Resources.Load<BigDoubleSettings>("BigDoubleSettings").GetDefaultKvpOrInfoNull();

            if (CurDoublePair.Value == null)
            {
                Debug.LogError($"BigDoubleInfo is null! check your setting file, key: {CurDoublePair.Key}");
                return number.ToString(CultureInfo.InvariantCulture);
            }

            var curDoubleInfo = CurDoublePair.Value;
            int digitInterval = curDoubleInfo.digitInterval;
            string[] doubleUnits = curDoubleInfo.doubleUnits;

            string formattedNumber = $"{new TruncateExp(number)}";
            string[] split = formattedNumber.Split('+');
            int exponential = int.Parse(split[1], CultureInfo.InvariantCulture);
            string frontNumber = split[0].TrimEnd('e');

            int digitIndex = Math.Max(0, exponential / digitInterval);

            while (exponential % digitInterval != 0)
            {
                --exponential;
                var pointStrIndex = frontNumber.IndexOf('.');

                if (pointStrIndex >= frontNumber.Length - 1) // 소수점이 FrontNumber의 마지막에 있는 경우
                {
                    frontNumber = frontNumber
                        .Insert(pointStrIndex, "0");
                }
                else
                {
                    frontNumber = frontNumber
                        .Remove(pointStrIndex, 1)
                        .Insert(pointStrIndex + 1, ".");
                }
            }
            
            frontNumber = frontNumber.TrimEnd('.');

            var truncatedStr = new TruncateDouble(frontNumber).ToString(digitInterval.ToString(), CultureInfo.InvariantCulture);

            if (curDoubleInfo.isPoint)
            {
                return $"{truncatedStr}{doubleUnits[digitIndex]}";
            }
            else
            {
                string[] truncatedSplit = truncatedStr.Split('.');

                if (digitIndex == 0 || truncatedSplit.Length < 2)
                    return $"{truncatedSplit[0]}{doubleUnits[digitIndex]}";
                else
                {
                    var pointStr = truncatedSplit[1];

                    while (pointStr.Length < 4)
                        pointStr += "0";

                    pointStr = pointStr.TrimStart('0');

                    return $"{truncatedSplit[0]}{doubleUnits[digitIndex]} {pointStr}{doubleUnits[digitIndex - 1]}";
                }
            }
        }
    }
}