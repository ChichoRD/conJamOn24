using ReignCollectionSystem;
using System;
using UnityEngine;

namespace ReignBorderSystem
{
    [Serializable]
    internal struct BorderInfo
    {
        [field: SerializeField]
        public ReignLayoutType From { get; private set; }
        [field: SerializeField]
        public ReignLayoutType To { get; private set; }

        public BorderInfo(ReignLayoutType from, ReignLayoutType to)
        {
            From = from;
            To = to;
        }
    }
}