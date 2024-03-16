using ReignCollectionSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ReignBorderSystem.Placer
{
    internal class BorderPlacer : MonoBehaviour
    {
        [Serializable]
        private struct BorderPair
        {
            public BorderPair(Transform transform, BorderInfo borderInfo)
            {
                Transform = transform;
                BorderInfo = borderInfo;
            }

            [field: SerializeField]
            public Transform Transform { get; private set; }

            [field: SerializeField]
            public BorderInfo BorderInfo { get; private set; }

            public static Dictionary<Transform, BorderInfo> DictionaryFromPairs(IReadOnlyList<BorderPair> borderPairs)
            {
                var dictionary = new Dictionary<Transform, BorderInfo>();
                for (int i = 0; i < borderPairs.Count; i++)
                    dictionary[borderPairs[i].Transform] = borderPairs[i].BorderInfo;
                return dictionary;
            }
        }

        [SerializeField]
        private BorderPair[] _borderPairs;

        [SerializeField]
        private ReignLayout _reignLayout;

        private Dictionary<Transform, BorderInfo> _borders;

        private void Awake()
        {
            _borders = BorderPair.DictionaryFromPairs(_borderPairs);
        }

        public bool TryPlaceBorder(Transform transform, IBorder border)
        {
            if (!_borders.TryGetValue(transform, out BorderInfo borderInfo))
                return false;

            return border.PlaceIn(_reignLayout, borderInfo.from)
                && border.PlaceIn(_reignLayout, borderInfo.to);
        }
    }
}