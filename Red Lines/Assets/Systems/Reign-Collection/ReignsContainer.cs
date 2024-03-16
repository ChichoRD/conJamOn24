using ReignSystem;
using ReignSystem.Factory;
using ReignSystem.Modifier;
using ReignSystem.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ReignCollectionSystem
{
    [CreateAssetMenu(fileName = "ReignsContainer", menuName = "Reign/Collection/ReignsContainer")]
    internal class ReignsContainer : ScriptableObject
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

            public static IEnumerable<(Reign reign, Dictionary<RelationParameterType, float> outerDefaults)> Create(ReignFactoryCreationPair pair)
            {
                for (int i = 0; i < pair.Count; i++)
                    yield return (pair.Factory.Create(), pair.Factory.DefaultOuterParameters);
            }

            public static IEnumerable<(Reign reign, Dictionary<RelationParameterType, float> outerDefaults)> Create(IEnumerable<ReignFactoryCreationPair> pairs)
            {
                return pairs.SelectMany(Create);
            }
        }

        private Reign[] _reigns;
        private Reign[] _modifiedReigns;

        public IReadOnlyList<Reign> Reigns => _modifiedReigns;

        public IReadOnlyList<Reign> InitializeWith(IEnumerable<ReignFactoryCreationPair> factories)
        {
            (Reign reign, Dictionary<RelationParameterType, float> outerDefaults)[] reigns = ReignFactoryCreationPair.Create(factories).ToArray();
            _reigns = new Reign[reigns.Length];
            _modifiedReigns = new Reign[reigns.Length];

            for (int i = 0; i < reigns.Length; i++)
            {
                (Reign reign, Dictionary<RelationParameterType, float> outerDefault) = reigns[i];
                Dictionary<IParametrizableReign<InnerReignParameters>, OuterReignParameter> relations =
                    new Dictionary<IParametrizableReign<InnerReignParameters>, OuterReignParameter>(reigns.Length - 1);

                for (int j = 0; j < reigns.Length; j++)
                    if (i != j)
                        relations[reigns[j].reign] = new OuterReignParameter(outerDefault);

                reigns[i].reign = reign.WithOuterReignParameters(relations);

                _reigns[i] = reigns[i].reign;
                _modifiedReigns[i] = reigns[i].reign;
            }

            return _modifiedReigns;
        }

        public IReadOnlyList<Reign> ApplyModifications()
        {
            _reigns = new Reign[_modifiedReigns.Length];
            Array.Copy(_modifiedReigns, _reigns, _reigns.Length);

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
                || _modifiedReigns[reignIndex].Accept<TModifier, TData, Reign>(modifier, out Reign modifiedReign))
                return false;

            _modifiedReigns[reignIndex] = modifiedReign;
            return true;
        }
    }
}