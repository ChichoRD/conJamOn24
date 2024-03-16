using System.Collections.Generic;

namespace ReignSystem.Parameter
{
    public readonly struct InnerReignParameters : IParametrizableReign<IReadOnlyDictionary<ReignParameterType, float>>
    {
        public readonly IReadOnlyDictionary<ReignParameterType, float> values;
        IReadOnlyDictionary<ReignParameterType, float> IParametrizableReign<IReadOnlyDictionary<ReignParameterType, float>>.Parameter => values;

        public InnerReignParameters(IReadOnlyDictionary<ReignParameterType, float> values)
        {
            this.values = values;
        }

    }
}