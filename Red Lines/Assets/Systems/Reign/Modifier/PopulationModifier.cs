using UnityEngine;

namespace ReignSystem.Modifier
{
    internal class PopulationModifier : MonoBehaviour, IReignModifier<Reign, Reign>
    {
        public Reign Modify(Reign value)
        {
            return value.WithInnerReignParameters(
                value.Parameter.WithPopulation(
                    value.Parameter.population + value.Parameter.content));
        }
    }

    internal class WaterModifier : MonoBehaviour, IReignModifier<Reign, Reign>
    {
        public Reign Modify(Reign value)
        {
            return value.WithInnerReignParameters(
                value.Parameter.WithWater(
                    value.Parameter.water * value.Parameter);
        }
    }
}