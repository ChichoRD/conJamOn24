using ReignSystem;
using ReignSystem.Modifier;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ReignCollectionSystem
{
    public class ReignLayout : MonoBehaviour, IObservableReignContainer
    {
        [Serializable]
        private struct ReignLayoutFactoryPair
        {
            public ReignLayoutFactoryPair(ReignLayoutType reignLayoutType, ReignsContainer.ReignFactoryCreationPair reignFactory)
            {
                ReignLayoutType = reignLayoutType;
                ReignFactory = reignFactory;
            }

            [field: SerializeField]
            public ReignLayoutType ReignLayoutType { get; private set; }

            [field: SerializeField]
            public ReignsContainer.ReignFactoryCreationPair ReignFactory { get; private set; }

            public static IReadOnlyList<ReignsContainer.ReignFactoryCreationPair> FactoriesFrom(IReadOnlyList<ReignLayoutFactoryPair> factoryPairs) =>
                factoryPairs.Select(pair => pair.ReignFactory).ToArray();

            public static Dictionary<ReignLayoutType, int> DictionaryFromCreation(IReadOnlyList<ReignLayoutFactoryPair> factoryPairs, ReignsContainer container)
            {
                Dictionary<ReignLayoutType, int> result = new Dictionary<ReignLayoutType, int>();
                IReadOnlyList<ReignsContainer.ReignFactoryCreationPair> reignFactories = FactoriesFrom(factoryPairs);
                IReadOnlyList<Reign> reigns = container.InitializeWith(reignFactories);

                for (int i = 0; i < reigns.Count; i++)
                    result[factoryPairs[i].ReignLayoutType] = i;

                return result;
            }
        }

        [SerializeField]
        private ReignsContainer _reignsContainer;

        [SerializeField]
        private ReignLayoutFactoryPair[] _reignFactories;

        [SerializeField]
        private bool _createOnAwake = true;
        private Dictionary<ReignLayoutType, int> _reigns;

        public event Action<Reign> ReignModified
        {
            add => _reignsContainer.ReignModified += value;
            remove => _reignsContainer.ReignModified -= value;
        }

        public event Action<Reign> ReignModificationApplied
        {
            add => _reignsContainer.ReignModificationApplied += value;
            remove => _reignsContainer.ReignModificationApplied -= value;
        }

        private void Awake()
        {
            if (_createOnAwake)
                CreateReigns();
        }

        private void CreateReigns()
        {
            _reigns = ReignLayoutFactoryPair.DictionaryFromCreation(_reignFactories, _reignsContainer);
        }

        public bool TryGetReign(ReignLayoutType reignLayoutType, out Reign reign)
        {
            reign = default;
            if (!_reigns.TryGetValue(reignLayoutType, out var index))
                return false;

            reign = _reignsContainer.Reigns[index];
            return true;
        }

        public bool ModifyReign<TModifier, TData>(ReignLayoutType reignLayoutType, TModifier reignModifier)
            where TModifier : IReignModifier<Reign, TData> =>
            _reigns.TryGetValue(reignLayoutType, out var index)
            && _reignsContainer.ApplyModifierTo<TModifier, TData>(index, reignModifier);
    }
}