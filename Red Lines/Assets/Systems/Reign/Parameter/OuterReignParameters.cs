using ReignSystem.Parameter.Data;
using System.Collections.Generic;
using System.Linq;

namespace ReignSystem.Parameter
{
    public readonly struct OuterReignParameters<TReign>
    {
        public float ConflictCount => _values.Values.Sum(x => x.conflict);
        public BorderStatus BestBorder => _values.Values.OrderByDescending(x => x.health).FirstOrDefault();

        private readonly IReadOnlyDictionary<TReign, BorderStatus> _values;
        public IReadOnlyDictionary<TReign, BorderStatus> Relationships => _values;
        public OuterReignParameters(IEnumerable<KeyValuePair<TReign, BorderStatus>> values)
        {
            _values = new Dictionary<TReign, BorderStatus>(values);
        }

        public static OuterReignParameters<TReign> FromEmpty() =>
            new OuterReignParameters<TReign>(new Dictionary<TReign, BorderStatus>());

        public override string ToString()
        {
            return string.Join(", ", _values);
        }
    }
}