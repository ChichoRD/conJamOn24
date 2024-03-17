using System.Linq;
using UnityEngine;

namespace ReignSystem.Modifier
{
    internal class WaterConsumptionModifier : MonoBehaviour, IReignModifier<Reign, Reign>
    {
        public Reign Modify(Reign value)
        {
            return value.WithInnerReignParameters(
                value.InnerParameters.WithWaterConsumption(
                    value.Populations.Sum(p => p.species.waterConsumption * p.size)));
        }
    }
}