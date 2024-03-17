using System.Linq;
using UnityEngine;

namespace ReignSystem.Modifier
{
    internal class FoodConsumptionModifier : MonoBehaviour, IReignModifier<Reign, Reign>
    {
        public Reign Modify(Reign value)
        {
            return value.WithInnerReignParameters(
                value.InnerParameters.WithFoodConsumption(
                    value.Populations.Sum(p => p.species.foodConsumption * p.size)));
        }
    }
}