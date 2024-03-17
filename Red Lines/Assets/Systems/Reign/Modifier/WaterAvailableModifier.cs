using UnityEngine;

namespace ReignSystem.Modifier
{
    internal class WaterAvailableModifier : MonoBehaviour, IReignModifier<Reign, Reign>
    {
        public Reign Modify(Reign value)
        {
            return value.WithInnerReignParameters(
                value.InnerParameters.WithWaterAvailable(
                    value.InnerParameters.waterAvailable * value.InnerParameters.waterGrowthRate - value.InnerParameters.waterConsumption));
        }
    }
}