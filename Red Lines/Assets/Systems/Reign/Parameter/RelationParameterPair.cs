using System;
using System.Collections.Generic;
using UnityEngine;

namespace ReignSystem.Parameter
{
    [Serializable]
    internal struct RelationParameterPair
    {
        [field: SerializeField]
        public RelationParameterType Type { get; private set; }
        [field: SerializeField]
        public float Value { get; private set; }

        public RelationParameterPair(RelationParameterType type, float value)
        {
            Type = type;
            Value = value;
        }

        public static Dictionary<RelationParameterType, float> DictionaryFrom(IEnumerable<RelationParameterPair> pairs)
        {
            var dictionary = new Dictionary<RelationParameterType, float>();
            foreach (var pair in pairs)
                dictionary[pair.Type] = pair.Value;
            return dictionary;
        }
    }
}