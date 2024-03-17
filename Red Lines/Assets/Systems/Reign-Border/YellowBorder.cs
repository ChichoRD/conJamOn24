using ReignSystem;
using ReignSystem.Modifier;
using ReignSystem.Parameter;
using UnityEngine;

namespace ReignBorderSystem
{
    internal readonly struct YellowBorder : IBorder<Reign>, IReignModifier<Reign, Reign>
    {
        private readonly float _comunicationAugment;
        private readonly float _economyAugment;
        private readonly float _economyFactor;
        private readonly Reign _otherReign;

        public YellowBorder(float comunicationAugment, float economyAugment, float economyFactor, Reign otherReign)
        {
            _comunicationAugment = comunicationAugment;
            _economyAugment = economyAugment;
            _economyFactor = economyFactor;
            _otherReign = otherReign;
        }

        public IReignModifier<Reign, Reign> ReignModifier => this;

        public Reign Modify(Reign value)
        {
            OuterReignParameter outerReignParameter = value.OuterReignParameters.Relationships[_otherReign.ID];
            InnerReignParameters innerReignParameters = value.Parameter;

            return value.WithOuterReignParametersFor(
                    _otherReign.ID,
                    outerReignParameter.WithComunication(outerReignParameter.comunication + _comunicationAugment * Mathf.Pow(innerReignParameters.economy, _economyFactor)))
                .WithInnerReignParameters(
                    innerReignParameters.WithEconomy(innerReignParameters.economy + _economyAugment));
        }
    }
}