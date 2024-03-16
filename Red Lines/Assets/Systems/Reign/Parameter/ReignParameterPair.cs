using System;
using System.Collections.Generic;
using UnityEngine;

namespace ReignSystem.Parameter
{
    [Serializable]
    internal struct ReignParameterPair
    {
        [field: SerializeField]
        public ReignParameterType Type { get; private set; }
        [field: SerializeField]
        public float Value { get; private set; }

        public ReignParameterPair(ReignParameterType type, float value)
        {
            Type = type;
            Value = value;
        }
        
        public static Dictionary<ReignParameterType, float> DictionaryFrom(IEnumerable<ReignParameterPair> pairs)
        {
            var dictionary = new Dictionary<ReignParameterType, float>();
            foreach (var pair in pairs)
                dictionary[pair.Type] = pair.Value;
            return dictionary;
        }
    }
}