using ReignSystem;
using ReignSystem.Parameter;

namespace ReignBorderSystem.Data
{
    internal readonly struct Comunication
    {
        public readonly float value;

        public Comunication(float value)
        {
            this.value = value;
        }

        public static Comunication FromReignWith(IParametrizableReign<OuterReignParameters<IParametrizableReign<InnerReignParameters>>> reign, IParametrizableReign<InnerReignParameters> other)
        {
            return reign.Parameter.values.TryGetValue(other, out var value)
                && value.values.TryGetValue(RelationParameterType.Comunication, out var comunication)
                ? new Comunication(comunication)
                : new Comunication(0.0f);
        }
    }
}