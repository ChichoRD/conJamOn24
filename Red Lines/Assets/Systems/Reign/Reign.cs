using ReignSystem.Modifier;
using ReignSystem.Parameter;
using System.Collections.Generic;

namespace ReignSystem
{
    public readonly struct Reign : IModifiableReign,
        IModifiableReign<Reign>,
        IParametrizableReign<InnerReignParameters>,
        IParametrizableReign<OuterReignParameters<int>>
    {
        private readonly int _id;
        private readonly InnerReignParameters _parametrizableInnerReign;
        private readonly OuterReignParameters<int> _parametrizableOuterReign;
        private readonly IEnumerable<IModifiableReign> _modifiableReigns;

        public Reign(int id, InnerReignParameters parametrizableInnerReign, OuterReignParameters<int> parametrizableOuterReign, IEnumerable<IModifiableReign> modifiableReigns)
        {
            _id = id;
            _parametrizableInnerReign = parametrizableInnerReign;
            _parametrizableOuterReign = parametrizableOuterReign;
            _modifiableReigns = modifiableReigns;
        }

        public int ID => _id;
        public OuterReignParameters<int> OuterReignParameters => _parametrizableOuterReign;
        public InnerReignParameters Parameter => _parametrizableInnerReign;
        OuterReignParameters<int> IParametrizableReign<OuterReignParameters<int>>.Parameter =>
            _parametrizableOuterReign;

        public bool Accept<TReignModifier, TData, TReign>(TReignModifier reignModifier, out TReign reign) where TReignModifier : IReignModifier<TReign, TData>
        {
            reign = default;
            bool accepted = false;

            if (reignModifier is IReignModifier<TReign, Reign> modifier)
                accepted |= Accept(modifier, out reign);

            foreach (var modifiableReign in _modifiableReigns)
                accepted |= modifiableReign.Accept<TReignModifier, TData, TReign>(reignModifier, out reign);
            return accepted;
        }

        public bool Accept<TReignModifier, TReign>(TReignModifier reignModifier, out TReign reign) where TReignModifier : IReignModifier<TReign, Reign>
        {
            reign = reignModifier.Modify(this);
            return true;
        }

        public Reign WithID(int id)
        {
            return new Reign(
                id,
                _parametrizableInnerReign,
                _parametrizableOuterReign,
                _modifiableReigns);
        }

        public Reign WithOuterReignParametersFor(int reignIndex, OuterReignParameter outerReignParameter)
        {
            var newOuterReignsParameters = new Dictionary<int, OuterReignParameter>(_parametrizableOuterReign.Relationships)
            {
                [reignIndex] = outerReignParameter
            };

            return new Reign(
                _id,
                _parametrizableInnerReign,
                new OuterReignParameters<int>
                    (newOuterReignsParameters),
                _modifiableReigns);
        }

        public Reign WithOuterReignParameters(IEnumerable<KeyValuePair<int, OuterReignParameter>> outerReignsParameters)
        {
            var newOuterReignsParameters = new Dictionary<int, OuterReignParameter>();
            foreach (var (reign, parameter) in outerReignsParameters)
                newOuterReignsParameters[reign] = parameter;

            return new Reign(
                _id,
                _parametrizableInnerReign,
                new OuterReignParameters<int>
                    (newOuterReignsParameters),
                _modifiableReigns);
        }

        public Reign WithInnerReignParameters(InnerReignParameters innerReignParameters)
        {
            return new Reign(
                _id,
                innerReignParameters,
                _parametrizableOuterReign,
                _modifiableReigns);
        }

        //public override string ToString()
        //{
        //    return $"Inner: {_parametrizableInnerReign}, Outer: {_parametrizableOuterReign}";
        //}

        public string AsString()
        {
            return $"ID: {_id}, Inner: {_parametrizableInnerReign}, Outer: {_parametrizableOuterReign}";
        }
    }
}