using UnityEngine;

namespace ReignSystem.Modifier
{
    internal class FoodAvailableModifier : MonoBehaviour, IReignModifier<Reign, Reign>
    {
        public Reign Modify(Reign value)
        {
            return value.WithInnerReignParameters(
                value.InnerParameters.WithFoodAvailable(
                    value.InnerParameters.food - value.InnerParameters.foodConsumption));
        }
    }
}