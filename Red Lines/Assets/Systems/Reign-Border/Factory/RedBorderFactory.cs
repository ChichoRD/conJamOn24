﻿using ReignSystem;
using UnityEngine;

namespace ReignBorderSystem.Factory
{
    internal class RedBorderFactory : MonoBehaviour, IBorderFactory
    {
        [SerializeField]
        private float _minComunicationReduction;

        [SerializeField]
        private float _maxComunicationReduction;

        public IBorder CreateBetween(in Reign from, in Reign to) =>
            new RedBorder(Random.Range(_minComunicationReduction, _maxComunicationReduction), to);
    }
}
