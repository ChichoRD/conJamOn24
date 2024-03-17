using System.Linq;
using UnityEngine;

namespace ReignSystem.Modifier
{
    internal class PopulationModifier : MonoBehaviour, IReignModifier<Reign, Reign>
    {
        public Reign Modify(Reign value)
        {
            float externalConflicts = value.OuterParameters.ConflictCount / value.OuterParameters.Relationships.Count;
            return value.WithPopulations(
                value.Populations.Select(p =>
                {
                    float growth = p.satisfaction * (value.InnerParameters.waterAvailable / p.species.waterConsumption + value.InnerParameters.foodAvailable / p.species.foodConsumption) / (2.0f * p.size);
                    float newPopulation = value.Imigrations.emigrations[p.species].emigrants - value.Emigrations.emigrations[p.species].emigrants + p.size * growth * (value.InnerParameters.internalConflict ? 0.75f : 1.0f + externalConflicts) * 0.5f;
                    return p.WithSize(newPopulation);
                })
                .ToArray());
        }
    }
}