using System.Collections.Generic;

namespace ReignSystem.Parameter
{
    public readonly struct OuterReignParameter
    {
        public readonly IReadOnlyDictionary<RelationParameterType, float> values;

        public OuterReignParameter(IReadOnlyDictionary<RelationParameterType, float> values)
        {
            this.values = values;
        }
    }
}