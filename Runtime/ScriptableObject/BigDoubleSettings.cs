using System.Collections.Generic;
using LongMan.GameUtil;
using UnityEngine;

namespace LongMan.BigDouble
{
    [CreateAssetMenu(fileName = "BigDoubleSettings", menuName = "LongMan/BigDoubleSettings")]
    public class BigDoubleSettings : ScriptableObject
    {
        public string defaultKey;
        public GenericDictionary<string, BigDoubleInfo> doubleUnitDictionary;

        public void ChangeDoubleUnits(string newKey)
        {
            if (doubleUnitDictionary.ContainsKey(newKey) == false)
                return;

            BigDoubleExtensions.CurDoublePair = new KeyValuePair<string, BigDoubleInfo>
                (newKey, doubleUnitDictionary[newKey]);
        }

        public KeyValuePair<string, BigDoubleInfo> GetDefaultKvpOrInfoNull()
        {
            if (doubleUnitDictionary.ContainsKey(defaultKey) == false)
                return new KeyValuePair<string, BigDoubleInfo>();

            return new KeyValuePair<string, BigDoubleInfo>(defaultKey, doubleUnitDictionary[defaultKey]);
        }
    }
}