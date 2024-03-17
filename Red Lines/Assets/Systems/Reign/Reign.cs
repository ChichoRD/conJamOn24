using ReignSystem.Modifier;
using ReignSystem.Parameter;
using System.Collections.Generic;

namespace ReignSystem
{
    public readonly struct Reign : IModifiableReign,
        IModifiableReign<Reign>,
        IParametrizableReign<InnerReignParameters>,
        IParametrizableReign<OuterReignParameters<IParametrizableReign<InnerReignParameters>>>
    {
        private readonly InnerReignParameters _parametrizableInnerReign;
        private readonly OuterReignParameters<IParametrizableReign<InnerReignParameters>> _parametrizableOuterReign;
        private readonly IEnumerable<IModifiableReign> _modifiableReigns;

        public Reign(InnerReignParameters parametrizableInnerReign, OuterReignParameters<IParametrizableReign<InnerReignParameters>> parametrizableOuterReign, IEnumerable<IModifiableReign> modifiableReigns)
        {
            _parametrizableInnerReign = parametrizableInnerReign;
            _parametrizableOuterReign = parametrizableOuterReign;
            _modifiableReigns = modifiableReigns;
        }

        public OuterReignParameters<IParametrizableReign<InnerReignParameters>> OuterReignParameters => _parametrizableOuterReign;
        public InnerReignParameters Parameter => _parametrizableInnerReign;
        OuterReignParameters<IParametrizableReign<InnerReignParameters>> IParametrizableReign<OuterReignParameters<IParametrizableReign<InnerReignParameters>>>.Parameter =>
            _parametrizableOuterReign;

        public bool Accept<TReignModifier, TData, TReign>(TReignModifier reignModifier, out TReign reign) where TReignModifier : IReignModifier<TReign, TData>
        {
            reign = default;
            bool accepted = false;
            foreach (var modifiableReign in _modifiableReigns)
                accepted |= modifiableReign.Accept<TReignModifier, TData, TReign>(reignModifier, out reign);
            return accepted;
        }

        public bool Accept<TReignModifier, TReign>(TReignModifier reignModifier, out TReign reign) where TReignModifier : IReignModifier<TReign, Reign>
        {
            reign = reignModifier.Modify(this);
            return true;
        }

        public Reign WithOuterReignParametersFor(IParametrizableReign<InnerReignParameters> reign, OuterReignParameter outerReignParameter)
        {
            var newOuterReignsParameters = new Dictionary<IParametrizableReign<InnerReignParameters>, OuterReignParameter>(_parametrizableOuterReign.Relationships);
            newOuterReignsParameters[reign] = outerReignParameter;

            return new Reign(
                _parametrizableInnerReign,
                new OuterReignParameters<IParametrizableReign<InnerReignParameters>>
                    (newOuterReignsParameters),
                _modifiableReigns);
        }

        public Reign WithOuterReignParameters(IEnumerable<KeyValuePair<IParametrizableReign<InnerReignParameters>, OuterReignParameter>> outerReignsParameters)
        {
            var newOuterReignsParameters = new Dictionary<IParametrizableReign<InnerReignParameters>, OuterReignParameter>();
            foreach (var (reign, parameter) in outerReignsParameters)
                newOuterReignsParameters[reign] = parameter;

            return new Reign(
                _parametrizableInnerReign,
                new OuterReignParameters<IParametrizableReign<InnerReignParameters>>
                    (newOuterReignsParameters),
                _modifiableReigns);
        }
    }
}