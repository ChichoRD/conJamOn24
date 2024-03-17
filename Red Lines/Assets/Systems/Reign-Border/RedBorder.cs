using ReignSystem;
using ReignSystem.Modifier;
using ReignSystem.Parameter;

namespace ReignBorderSystem
{
    internal readonly struct RedBorder : IBorder<Reign>, IReignModifier<Reign, Reign>
    {
        private readonly float _comunicationReduction;
        private readonly Reign _otherReign;

        public RedBorder(float comunicationReduction, Reign otherReign)
        {
            _comunicationReduction = comunicationReduction;
            _otherReign = otherReign;
        }

        public IReignModifier<Reign, Reign> ReignModifier => this;

        public Reign Modify(Reign value)
        {
            OuterReignParameter outerReignParameter = value.OuterReignParameters.Relationships[_otherReign.ID];
            return value.WithOuterReignParametersFor(_otherReign.ID, outerReignParameter.WithComunication(outerReignParameter.comunication - _comunicationReduction));
        }
    }
}