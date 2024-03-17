using ReignBorderSystem.Factory;
using ReignCollectionSystem;
using ReignSystem;
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

#if UNITY_EDITOR
        [SerializeField]
        private Transform[] _borderTransforms;
#endif

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

            return border.PlaceIn(_reignLayout, borderInfo.From)
                && border.PlaceIn(_reignLayout, borderInfo.To);
        }

        public bool TryCreateAndPlace(Transform transform, IBorderFactory borderFactory)
        {
            if (!TryGetReigns(transform, out BorderInfo borderInfo, out Reign from, out Reign to))
                return false;

            return borderFactory.CreateBetween(in from, in to).PlaceIn(_reignLayout, borderInfo.From)
                && borderFactory.CreateBetween(in to, in from).PlaceIn(_reignLayout, borderInfo.To);
        }

        public bool TryGetReigns(Transform transform, out Reign from, out Reign to)
        {
            from = default;
            to = default;

            return _borders.TryGetValue(transform, out BorderInfo borderInfo)
                && _reignLayout.TryGetReign(borderInfo.From, out from)
                && _reignLayout.TryGetReign(borderInfo.To, out to);
        }

        public bool TryGetReigns(Transform transform, out BorderInfo borderInfo, out Reign from, out Reign to)
        {
            from = default;
            to = default;

            return _borders.TryGetValue(transform, out borderInfo)
                && _reignLayout.TryGetReign(borderInfo.From, out from)
                && _reignLayout.TryGetReign(borderInfo.To, out to);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_borderTransforms == null || _borderTransforms.Length == 0)
                return;

            _borderPairs = new BorderPair[_borderTransforms.Length];
            for (int i = 0; i < _borderTransforms.Length; i++)
                _borderPairs[i] = new BorderPair(_borderTransforms[i], new BorderInfo());

            _borderTransforms = new Transform[0];
        }
#endif
    }
}