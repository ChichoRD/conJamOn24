using ReignSystem.Modifier;

namespace ReignSystem
{
    public interface IModifiableReign
    {
        bool Accept<TReignModifier, TData, TReign>(TReignModifier reignModifier, out TReign reign)
            where TReignModifier : IReignModifier<TReign, TData>;
    }

    public interface IModifiableReign<out TData> : IModifiableReign
    {
        bool IModifiableReign.Accept<TReignModifier, UData, TReign>(TReignModifier reignModifier, out TReign reign)
        {
            reign = default;
            return reignModifier is IReignModifier<TReign, TData> modifier && Accept(modifier, out reign);
        }

        bool Accept<TReignModifier, TReign>(TReignModifier reignModifier, out TReign reign)
            where TReignModifier : IReignModifier<TReign, TData>;
    }
}