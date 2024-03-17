using System.Collections.Generic;

namespace ReignSystem.Parameter
{
    public readonly struct OuterReignParameters<TReign>
    {
        private readonly IReadOnlyDictionary<TReign, OuterReignParameter> _values;
        public IReadOnlyDictionary<TReign, OuterReignParameter> Relationships => _values;
        public OuterReignParameters(IEnumerable<KeyValuePair<TReign, OuterReignParameter>> values)
        {
            _values = new Dictionary<TReign, OuterReignParameter>(values);
        }

        public static OuterReignParameters<TReign> FromEmpty() =>
            new OuterReignParameters<TReign>(new Dictionary<TReign, OuterReignParameter>());

        public override string ToString()
        {
            return string.Join(", ", _values);
        }
    }
}