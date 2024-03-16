using ReignSystem.Parameter;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ReignSystem.Factory
{
    [CreateAssetMenu(fileName = "ReignFactory", menuName = "Reign/Factory/ReignFactory")]
    public class ReignFactory : ScriptableObject, IReignFactory<Reign>
    {
        [SerializeField]
        private ModifiableReignFactory[] _modifiableReignFactories;

        [SerializeField]
        private ReignParameterPair[] _defaultInnerParameters;

        [SerializeField]
        private RelationParameterPair[] _defaultOuterParameters;

        public Reign Create()
        {
            return new Reign(
                new InnerReignParameters(ReignParameterPair.DictionaryFrom(_defaultInnerParameters)),
                OuterReignParameters<IParametrizableReign<InnerReignParameters>>.FromEmpty(),
                _modifiableReignFactories.Select(Create));

            static IModifiableReign Create(ModifiableReignFactory factory) => factory.Create();
        }

        public Dictionary<ReignParameterType, float> DefaultInnerParameters => ReignParameterPair.DictionaryFrom(_defaultInnerParameters);
        public Dictionary<RelationParameterType, float> DefaultOuterParameters => RelationParameterPair.DictionaryFrom(_defaultOuterParameters);
    }
}