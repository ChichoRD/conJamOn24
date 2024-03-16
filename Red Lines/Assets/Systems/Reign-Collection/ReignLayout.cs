using ReignSystem;
using ReignSystem.Modifier;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ReignCollectionSystem
{
    public class ReignLayout : MonoBehaviour
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

            public static Dictionary<ReignLayoutType, int> DictionaryFromCreation(IReadOnlyList<ReignLayoutFactoryPair> factoryPairs, ReignsContainer container)
            {
                var dictionary = new Dictionary<ReignLayoutType, int>();
                for (int i = 0; i < container.InitializeWith(factoryPairs.Select(f => f.ReignFactory)).Count; i++)
                    dictionary[factoryPairs[i].ReignLayoutType] = i;
                return dictionary;
            }
        }

        [SerializeField]
        private ReignsContainer _reignsContainer;

        [SerializeField]
        private ReignLayoutFactoryPair[] _reignFactories;

        [SerializeField]
        private bool _createOnAwake = true;

        private Dictionary<ReignLayoutType, int> _reigns;
        public IReadOnlyDictionary<ReignLayoutType, int> Reigns => _reigns;

        private void Awake()
        {
            if (_createOnAwake)
                CreateReigns();
        }

        private void CreateReigns()
        {
            _reigns = ReignLayoutFactoryPair.DictionaryFromCreation(_reignFactories, _reignsContainer);
        }

        public bool ModifyReign<TModifier, TData>(ReignLayoutType reignLayoutType, TModifier reignModifier)
            where TModifier : IReignModifier<Reign, TData> =>
            _reigns.TryGetValue(reignLayoutType, out var index)
            && _reignsContainer.ApplyModifierTo<TModifier, TData>(index, reignModifier);
    }
}