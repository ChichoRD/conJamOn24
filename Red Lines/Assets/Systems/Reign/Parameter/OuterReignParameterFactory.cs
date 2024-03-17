using System;
using UnityEngine;

namespace ReignSystem.Parameter
{
    [Serializable]
    public struct OuterReignParameterFactory
    {
        [field: SerializeField]
        public float Comunication { get; private set; }
        [field: SerializeField]
        public float Sympathy { get; private set; }
        [field: SerializeField]
        public float Hatred { get; private set; }

        public OuterReignParameterFactory(float comunication, float sympathy, float hatred)
        {
            Comunication = comunication;
            Sympathy = sympathy;
            Hatred = hatred;
        }

        public OuterReignParameterFactory(OuterReignParameter parameters)
        {
            Comunication = parameters.comunication;
            Sympathy = parameters.sympathy;
            Hatred = parameters.hatred;
        }

        public OuterReignParameter Create() =>
            new OuterReignParameter(Comunication, Sympathy, Hatred);
    }
}