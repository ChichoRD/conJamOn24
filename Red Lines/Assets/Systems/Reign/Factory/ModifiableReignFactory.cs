using ReignSystem.Modifier;
using UnityEngine;

namespace ReignSystem.Factory
{
    public abstract class ModifiableReignFactory : ScriptableObject, IReignFactory<IModifiableReign>
    {
        public abstract IModifiableReign Create();

        protected readonly struct NullModifiableReign : IModifiableReign
        {
            public readonly static NullModifiableReign Instance = new NullModifiableReign();

            public bool Accept<TReignModifier, TData, TReign>(TReignModifier reignModifier, out TReign reign)
                where TReignModifier : IReignModifier<TReign, TData>
            {
                reign = default;
                return false;
            }
        }
    }
}