using System;
using UnityEngine;

namespace ReignSystem.Parameter
{
    [Serializable]
    public struct InnerReignParameterFactory
    {
        [field: SerializeField]
        public float Water { get; private set; }
        [field: SerializeField]
        public float Food { get; private set; }
        [field: SerializeField]
        public float Population { get; private set; }
        [field: SerializeField]
        public float Content { get; private set; }
        [field: SerializeField]
        public float Economy { get; private set; }
        [field: SerializeField]
        public float Agenda { get; private set; }

        public InnerReignParameterFactory(float water, float food, float population, float content, float economy, float agenda)
        {
            Water = water;
            Food = food;
            Population = population;
            Content = content;
            Economy = economy;
            Agenda = agenda;
        }

        public InnerReignParameterFactory(InnerReignParameters parameters)
        {
            Water = parameters.water;
            Food = parameters.food;
            Population = parameters.population;
            Content = parameters.content;
            Economy = parameters.economy;
            Agenda = parameters.agenda;
        }

        public InnerReignParameters Create() =>
            new InnerReignParameters(Water, Food, Population, Content, Economy, Agenda);
    }
}