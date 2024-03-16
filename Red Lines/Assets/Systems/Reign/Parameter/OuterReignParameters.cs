using System.Collections.Generic;

namespace ReignSystem.Parameter
{
    public readonly struct OuterReignParameters<TReign> : IParametrizableReign<IReadOnlyDictionary<TReign, OuterReignParameter>>
    {
        public readonly IReadOnlyDictionary<TReign, OuterReignParameter> values;
        IReadOnlyDictionary<TReign, OuterReignParameter> IParametrizableReign<IReadOnlyDictionary<TReign, OuterReignParameter>>.Parameter =>
            values;
        public OuterReignParameters(IReadOnlyDictionary<TReign, OuterReignParameter> values)
        {
            this.values = values;
        }

        public static OuterReignParameters<TReign> FromEmpty() =>
            new OuterReignParameters<TReign>(new Dictionary<TReign, OuterReignParameter>());
    }
}