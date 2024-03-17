using ReignSystem.Modifier;
using ReignSystem.Parameter;
using ReignSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal readonly struct WaterModifier : IReignModifier<Reign, Reign> {
        private readonly float _waterReign;
        private readonly float _waterConsumo;

        public WaterModifier(float waterConsu, float population) {
             _waterReign = waterConsu;
             _waterConsumo = population;
        }

        public Reign Modify(Reign value) {
            OuterReignParameter outerReignParameter = value.OuterReignParameters.Relationships[_otherReign.ID];
            InnerReignParameters innerReignParameters = value.Parameter;

            return value.WithOuterReignParametersFor(
                    _otherReign.ID,
                    outerReignParameter.WithComunication(outerReignParameter.comunication + _comunicationAugment * Mathf.Pow(innerReignParameters.economy, _waterFactor)))
                .WithInnerReignParameters(
                    innerReignParameters.WithEconomy(innerReignParameters.economy + _waterAugment));
        }
    }
}
