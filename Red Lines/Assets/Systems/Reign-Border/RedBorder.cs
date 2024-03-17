using ReignSystem;
using ReignSystem.Modifier;

namespace ReignBorderSystem
{
    internal readonly struct RedBorder : IBorder<Reign>, IReignModifier<Reign, Reign>
    {
        private readonly float _reduction;
        private readonly Reign _otherReign;

        public RedBorder(float reduction, Reign otherReign)
        {
            _reduction = reduction;
            _otherReign = otherReign;
        }

        public IReignModifier<Reign, Reign> ReignModifier => this;

        public Reign Modify(Reign value)
        {
            ReignSystem.Parameter.OuterReignParameter outerReignParameter = value.OuterReignParameters.Relationships[_otherReign];
            return value.WithOuterReignParametersFor(_otherReign, outerReignParameter.WithComunication(outerReignParameter.comunication - _reduction));
        }
    }
}