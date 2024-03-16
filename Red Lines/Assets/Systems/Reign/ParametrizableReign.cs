namespace ReignSystem
{
    internal readonly struct ParametrizableReign<T> : IParametrizableReign<T>
    {
        public T Parameter { get; }

        public ParametrizableReign(T parameter) =>
            Parameter = parameter;
    }
}