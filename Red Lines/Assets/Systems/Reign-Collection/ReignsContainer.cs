using ReignSystem;
using ReignSystem.Factory;
using ReignSystem.Modifier;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ReignCollectionSystem
{
    [CreateAssetMenu(fileName = "ReignsContainer", menuName = "Reign/Collection/ReignsContainer")]
    internal class ReignsContainer : ScriptableObject, IObservableReignContainer
    {
        [Serializable]
        public struct ReignFactoryCreationPair
        {
            public ReignFactoryCreationPair(ReignFactory factory, int count)
            {
                Factory = factory;
                Count = count;
            }

            [field: SerializeField]
            public ReignFactory Factory { get; private set; }
            [field: SerializeField]
            public int Count { get; private set; }
        }

        private Reign[] _reigns;
        private Reign[] _modifiedReigns;

        public IReadOnlyList<Reign> Reigns => _modifiedReigns;

        public event Action<Reign> ReignModified;
        public event Action<Reign> ReignModificationApplied;

        public IReadOnlyList<Reign> InitializeWith(IReadOnlyList<ReignFactoryCreationPair> factories)
        {
            Dictionary<int, ReignFactory> reignFactoryPairs = new Dictionary<int, ReignFactory>(factories.Count);
            _reigns = new Reign[factories.Sum(pair => pair.Count)];
            _modifiedReigns = new Reign[_reigns.Length];

            int index = 0;
            foreach (var pair in factories)
            {
                for (int i = 0; i < pair.Count; i++)
                {
                    _reigns[index] = pair.Factory.Create().WithID(index);
                    reignFactoryPairs[index] = pair.Factory;
                    index++;
                }
            }

            for (int i = 0; i < _reigns.Length; i++)
            {
                for (int j = 0; j < _reigns.Length; j++)
                {
                    if (i != j)
                        _reigns[i] = _reigns[i].WithOuterReignParametersFor(_reigns[j].ID, reignFactoryPairs[i].DefaultOuterParameters);
                }

                _modifiedReigns[i] = _reigns[i];
            }

            return _modifiedReigns;
        }

        public IReadOnlyList<Reign> ApplyModifications()
        {
            _reigns = new Reign[_modifiedReigns.Length];
            Array.Copy(_modifiedReigns, _reigns, _reigns.Length);

            foreach (var reign in _reigns)
                ReignModificationApplied?.Invoke(reign);

            return _reigns;
        }

        public IReadOnlyList<Reign> RevertModifications()
        {
            _modifiedReigns = new Reign[_reigns.Length];
            Array.Copy(_reigns, _modifiedReigns, _reigns.Length);

            return _modifiedReigns;
        }

        public bool ApplyModifierTo<TModifier, TData>(int reignIndex, TModifier modifier)
            where TModifier : IReignModifier<Reign, TData>
        {
            if (reignIndex < 0
                || reignIndex >= _modifiedReigns.Length 
                || !_modifiedReigns[reignIndex].Accept<TModifier, TData, Reign>(modifier, out Reign modifiedReign))
                return false;

            _modifiedReigns[reignIndex] = modifiedReign;
            ReignModified?.Invoke(_modifiedReigns[reignIndex]);
            return true;
        }
    }
}