using ReignSystem;

namespace ReignBorderSystem.Data
{
    internal readonly struct ReignWith<T>
    {
        public readonly Reign reign;
        public readonly T value;

        public ReignWith(Reign reign, T value)
        {
            this.reign = reign;
            this.value = value;
        }
    }
}