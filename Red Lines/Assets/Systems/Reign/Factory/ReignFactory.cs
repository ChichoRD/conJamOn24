using ReignSystem.Parameter;
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
        private InnerReignParameterFactory _defaultInnerParameters;

        [SerializeField]
        private OuterReignParameterFactory _defaultOuterParameters;

        public Reign Create()
        {
            return new Reign(
                0,
                _defaultInnerParameters.Create(),
                OuterReignParameters<int>.FromEmpty(),
                _modifiableReignFactories.Select(Create));

            static IModifiableReign Create(ModifiableReignFactory factory) => factory.Create();
        }

        public InnerReignParameters DefaultInnerParameters => _defaultInnerParameters.Create();
        public OuterReignParameter DefaultOuterParameters => _defaultOuterParameters.Create();
    }
}